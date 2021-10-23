using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    protected InventoryController inventoryController;
    protected TextBoxController textBoxController;
    protected bool dialogueBoxDisplaying = false;
    protected ReadUIController readUIController;
    private void Awake() {
        textBoxController = GameObject.Find("UI").transform.Find("TextBox").GetComponent<TextBoxController>();
        readUIController = GameObject.Find("UI").transform.Find("ReadObjectUI").GetComponent<ReadUIController>();
    }
    protected void Start()
    {
        textBoxController.dialogueBoxDisplaying += displayValue => {SetDialogueBoxDisplaying(displayValue);};
        readUIController.ReadStartOrElseEnd += (isReading) => {dialogueBoxDisplaying = isReading;};
        inventoryController = GameObject.FindWithTag("Inventory").GetComponent<InventoryController>();
        dialogueBoxDisplaying = readUIController.GetIsDisplaying() || textBoxController.GetIsDisplaying();
    }
    public abstract void InteractObjectResponse();
    private void SetDialogueBoxDisplaying(bool isDisplaying) {
        dialogueBoxDisplaying = isDisplaying;
    }
}
