using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.InputSystem;

public class TextBoxController : MonoBehaviour
{
    public Action<bool> dialogueBoxDisplaying;
    [SerializeField] private TextMeshProUGUI textBoxText = null;
    [SerializeField] private GameObject continueButton = null;
    [SerializeField] private char splitSentenceSymbol = ';'; // all interaction comments can be split to several text boxes by adding this character in between the text
    private TextBoxInputActions textBoxInputActions;
    private bool isDisplaying = false; // single source of truth for text box isDisplaying
    private bool currentTextDisplayFinished = true;
    [SerializeField] private float letterDisplayDelay = 0.025f;
    private float currentLetterDisplayDelay = 0f;
    private void Awake() {
        textBoxInputActions = new TextBoxInputActions();
    }
    private void OnEnable() {
        textBoxInputActions.Enable();
    }
    private void OnDisable() {
        textBoxInputActions.Disable();
    }
    private void Start() {
        gameObject.SetActive(false);
        dialogueBoxDisplaying += dialogueDisplaying => isDisplaying = dialogueDisplaying;
        textBoxInputActions.TextBox.DialogueProgression.performed += InteractOnDialogue;
    }
    public IEnumerator DisplayDialogue(string dialogueText) {
        if (isDisplaying)
            yield break;
        OpenDialogue();
        while (dialogueText.Length != 0) {
            currentLetterDisplayDelay = letterDisplayDelay;
            currentTextDisplayFinished = false;
            string curText = "";
            for (int i = 0; i < dialogueText.Length; i++)
                if (dialogueText[i] == splitSentenceSymbol) {
                    curText = dialogueText.Substring(0, i);
                    dialogueText = dialogueText.Substring(i+1);
                    break;
                }
            if (curText == "") {
                curText = dialogueText;
                dialogueText = "";
            }

            continueButton.SetActive(false);
            string buildingText = "";
            foreach (char v in curText) {
                buildingText += v;
                textBoxText.SetText(buildingText);
                yield return new WaitForSeconds(currentLetterDisplayDelay);
            }
            continueButton.SetActive(true);
            yield return new WaitUntil(() => currentTextDisplayFinished == true);
        }
        CloseDialogue();
    }

    private void InteractOnDialogue(InputAction.CallbackContext ctx) {
        if (!continueButton.activeSelf) {
            currentLetterDisplayDelay = 0f;
        } else {
            currentTextDisplayFinished = true;
        }
    }
    private void OpenDialogue() {
        dialogueBoxDisplaying(true);
        gameObject.SetActive(true);
    }
    private void CloseDialogue() {
        gameObject.SetActive(false);
        dialogueBoxDisplaying(false);
    }
    public bool GetIsDisplaying() {
        return isDisplaying;
    }
}
