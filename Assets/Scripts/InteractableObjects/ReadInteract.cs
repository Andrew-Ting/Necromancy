using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteract : Interactable
{
    [SerializeField] private ReadObject readObject = ReadObject.Scroll;
    [SerializeField] private List<string> textInPages = null;

    public override void InteractObjectResponse() {
        if (!dialogueBoxDisplaying) {
            readUIController.OpenText(readObject, textInPages);
        }
        else if (textBoxController.GetIsDisplaying()) {
            // do nothing; wait for text box to finish
        } // otherwise, readUIController must be displaying
        else if (!readUIController.IsOnLastPage()) {
            readUIController.TurnPageRight();
        }
        else {
            readUIController.CloseText();
        }
    }

    
}
