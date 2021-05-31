using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.InputSystem;

public class TextBoxController : MonoBehaviour
{
    public Action<bool> dialogueBoxDisplaying;
    [SerializeField] private TextMeshProUGUI textBoxText;
    [SerializeField] private GameObject continueButton;
    private TextBoxInputActions textBoxInputActions;
    private bool isDisplaying = false;
    private float letterDisplayDelay = 0.025f;
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
        gameObject.SetActive(true);
        continueButton.SetActive(false);
        dialogueBoxDisplaying(true);
        letterDisplayDelay = 0.025f;
        string curText = "";
        foreach (char v in dialogueText) {
            curText += v;
            textBoxText.SetText(curText);
            yield return new WaitForSeconds(letterDisplayDelay);
        }
        continueButton.SetActive(true);
    }

    private void InteractOnDialogue(InputAction.CallbackContext ctx) {
        Debug.Log("Reached!");
        if (!continueButton.activeSelf) {
            letterDisplayDelay = 0f;
        } else {
            CloseDialogue();
        }
    }
    public void CloseDialogue() {
        gameObject.SetActive(false);
        dialogueBoxDisplaying(false);
    }
}
