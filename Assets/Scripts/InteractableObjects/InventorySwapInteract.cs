using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum InteractType {ToggleVisibility, Animate, None};

[System.Serializable]
class InventorySwapDetails : InteractionDetails {
    public Sprite inputInventoryObject;
    public Sprite outputInventoryObject;
    public List<GameObject> inputMapObject; 
    public InteractType mapObjectChange;
}

public class InventorySwapInteract : Interactable
{
    [SerializeField] private InventorySwapDetails inputOutputItemExchange;
    [SerializeField] private string incorrectInteractionComment = "I don't think that will work.";
    private bool completedSwap = false;

    public override void InteractObjectResponse() {
        if (completedSwap)
            return;
        Sprite curSelection = inventoryController.GetCurrentSelection();
        if (inventoryController.IsHandSelection()) {
            if (!inputOutputItemExchange.inputInventoryObject) {
                HandleObjectInteractionMapChange(inputOutputItemExchange);
                StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.interactComment));
            } else {
                StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.examineComment));
            }
        }
        else if (inputOutputItemExchange.inputInventoryObject == curSelection) {
            completedSwap = true;
            StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.interactComment));
            inventoryController.DestroyCurrentSelection();
            HandleObjectInteractionMapChange(inputOutputItemExchange);
        } 
        else {
            StartCoroutine(textBoxController.DisplayDialogue(incorrectInteractionComment));
        }      
        inventoryController.SetToHandSelection();
    }

    private void HandleObjectInteractionMapChange(InventorySwapDetails inputOutputItemExchange) {
        completedSwap = true;
        if (inputOutputItemExchange.outputInventoryObject)
            inventoryController.PickupItem(inputOutputItemExchange.outputInventoryObject);
        switch (inputOutputItemExchange.mapObjectChange) {
            case InteractType.ToggleVisibility:
                foreach (GameObject obj in inputOutputItemExchange.inputMapObject) {
                    if (obj.activeSelf) {
                        if (obj.GetComponent<SpriteRenderer>())
                            obj.GetComponent<SpriteRenderer>().sprite = null;
                        if (obj.GetComponent<CircleCollider2D>())
                            Destroy(obj.GetComponent<CircleCollider2D>());
                        if (obj.GetComponent<BoxCollider2D>())
                            Destroy(obj.GetComponent<BoxCollider2D>());
                    }
                    else    
                        obj.SetActive(true);
                }
                break;
            case InteractType.Animate:
                foreach (GameObject obj in inputOutputItemExchange.inputMapObject) {
                    obj.GetComponent<Animator>().SetBool("interacting", true);
                }
                break;
            case InteractType.None:
                break;
        }
    }
}
