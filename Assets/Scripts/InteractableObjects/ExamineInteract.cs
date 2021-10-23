using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineInteract : Interactable
{
    [SerializeField] private InteractionDetails interactionComment = null;
    public override void InteractObjectResponse() {
        Sprite curSelection = inventoryController.GetCurrentSelection();
        if (inventoryController.IsHandSelection()) {
            StartCoroutine(textBoxController.DisplayDialogue(interactionComment.examineComment));
        }
        else {
            StartCoroutine(textBoxController.DisplayDialogue(interactionComment.interactComment));
        }      
        inventoryController.SetToHandSelection();
    }
}
