using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public enum ReadObject {
    Book,
    Scroll,
    Paper
}
public class ReadUIController : MonoBehaviour
{
    private GameObject bookObject;
    private GameObject scrollObject;
    private GameObject paperObject;
    private GameObject goLeftArrow;
    private GameObject goRightArrow;
    private GameObject closeReadingSymbol;
    private TextMeshProUGUI bookLeftPageText;
    private TextMeshProUGUI bookRightPageText;
    private TextMeshProUGUI scrollPageText;
    private TextMeshProUGUI paperPageText;
    private int currentPage = 1;
    private int pageCount;
    private ReadObject currentReadObject;
    private List <string> currentPageContent;
    public event Action<bool> ReadStartOrElseEnd;
    private bool isDisplaying = false; // single source of truth for isDisplaying for read objects
    // Start is called before the first frame update
    void Start()
    {
        bookObject = transform.Find("Book").gameObject;
        scrollObject = transform.Find("Scroll").gameObject;
        paperObject = transform.Find("Paper").gameObject;
        bookLeftPageText = bookObject.transform.Find("LeftPage").gameObject.GetComponent<TextMeshProUGUI>();
        bookRightPageText = bookObject.transform.Find("RightPage").gameObject.GetComponent<TextMeshProUGUI>();
        scrollPageText = scrollObject.transform.Find("Page").gameObject.GetComponent<TextMeshProUGUI>();
        paperPageText = paperObject.transform.Find("Page").gameObject.GetComponent<TextMeshProUGUI>();
        goLeftArrow = transform.Find("ContinueArrowLeft").gameObject;
        goRightArrow = transform.Find("ContinueArrowRight").gameObject;
        closeReadingSymbol = transform.Find("CloseReading").gameObject;
        ReadStartOrElseEnd += dialogueDisplaying => isDisplaying = dialogueDisplaying;
        currentPageContent = new List<string>();
        CloseText();
    }

    public void OpenText(ReadObject readObject, List<string> pages) {
        ReadStartOrElseEnd.Invoke(true);
        currentReadObject = readObject;
        currentPageContent = pages;
        currentPage = 1;
        closeReadingSymbol.SetActive(true);
        switch (readObject) {
            case ReadObject.Book:
                bookObject.SetActive(true);
                pageCount = (pages.Count / 2) + (pages.Count % 2);
                break;
            case ReadObject.Scroll:
                scrollObject.SetActive(true);
                pageCount = pages.Count;
                break;
            case ReadObject.Paper:
                paperObject.SetActive(true);
                pageCount = pages.Count;
                break;
        }
        SetPageTexts();
        ChangeArrowsDependingOnPageNumber();
    }
    public void CloseText() {
        switch (currentReadObject) {
            case ReadObject.Book:
                bookObject.SetActive(false);
                break;
            case ReadObject.Scroll:
                scrollObject.SetActive(false);
                break;
            case ReadObject.Paper:
                paperObject.SetActive(false);
                break;
        }
        goLeftArrow.SetActive(false);
        goRightArrow.SetActive(false);
        closeReadingSymbol.SetActive(false);
        ReadStartOrElseEnd.Invoke(false);
    }
    public void TurnPageRight() {
        currentPage++;
        SetPageTexts();
        ChangeArrowsDependingOnPageNumber();
    }
    public void TurnPageLeft() {
        currentPage--;
        SetPageTexts();
        ChangeArrowsDependingOnPageNumber();
    }
    public bool GetIsDisplaying() {
        return isDisplaying;
    }
    private void SetPageTexts() {
        switch (currentReadObject) {
            case ReadObject.Book:
                bookLeftPageText.text = currentPageContent[(currentPage - 1) * 2];
                if ((currentPage - 1) * 2 + 1 < currentPageContent.Count)
                    bookRightPageText.text = currentPageContent[(currentPage - 1) * 2 + 1];
                else bookRightPageText.text = "";
                break;
            case ReadObject.Scroll:
                scrollPageText.text = currentPageContent[currentPage - 1];
                break;
            case ReadObject.Paper:
                paperPageText.text = currentPageContent[currentPage - 1];
                break;
        }
    }
    public bool IsOnLastPage() {
        switch (currentReadObject) {
            case ReadObject.Book:
                if (currentPageContent.Count == currentPage * 2 || currentPageContent.Count == currentPage * 2 - 1)
                    return true;
                else return false;
            case ReadObject.Scroll:
                if (currentPageContent.Count == currentPage)
                    return true;
                else return false;
            case ReadObject.Paper:
                if (currentPageContent.Count == currentPage)
                    return true;
                else return false;
        }
        return false;
    }
    private void ChangeArrowsDependingOnPageNumber() {
        if (currentPage < 1)
            Debug.LogError("The current page of the book is < 1. This shouldn't happen");
        if (currentPage == 1)
            goLeftArrow.SetActive(false);
        else if (!goLeftArrow.activeSelf)
            goLeftArrow.SetActive(true);
        if (currentPage == pageCount)
            goRightArrow.SetActive(false);
        else if (!goRightArrow.activeSelf)
            goRightArrow.SetActive(true);
        if (currentPage > pageCount) 
            Debug.LogError("The current page of the book is > than number of pages in the book. This shouldn't happen");
    }
}
