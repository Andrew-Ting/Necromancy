using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum InteractType {ToggleVisibility, Animate, None};

[System.Serializable]
class InventorySwapDetails : InteractionDetails {
    public Sprite inputInventoryObject = null;
    public Sprite outputInventoryObject = null;
    public List<GameObject> inputMapObject = null; 
    public InteractType mapObjectChange = InteractType.None;
}

public class InventorySwapInteract : Interactable
{
    [SerializeField] private InventorySwapDetails inputOutputItemExchange = null;
    [SerializeField] private string incorrectInteractionComment = "I don't think that will work.";
    private bool completedSwap = false;
    [SerializeField] private InteractionPersistentData saveDataVariable = null;
    new void Start() {
        if (!saveDataVariable)
            Debug.LogWarning(gameObject + " does not have an interactionpersistencedata attached to it; the interaction will be refreshed when the player leaves the scene.");
        base.Start();
        completedSwap = saveDataVariable.IsCompleted();
        if (completedSwap)
            UpdateMapScene();
    }

    public override void InteractObjectResponse() {
        if (completedSwap || dialogueBoxDisplaying)
            return;
        Sprite curSelection = inventoryController.GetCurrentSelection();
        if (inventoryController.IsHandSelection()) {
            if (!inputOutputItemExchange.inputInventoryObject) {
                HandleObjectInteractionMapChange();
                StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.interactComment));
            } else {
                StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.examineComment));
            }
        }
        else if (inputOutputItemExchange.inputInventoryObject == curSelection) {
            completedSwap = true;
            StartCoroutine(textBoxController.DisplayDialogue(inputOutputItemExchange.interactComment));
            inventoryController.DestroyCurrentSelection();
            HandleObjectInteractionMapChange();
        } 
        else {
            StartCoroutine(textBoxController.DisplayDialogue(incorrectInteractionComment));
        }      
        inventoryController.SetToHandSelection();
    }

    private void HandleObjectInteractionMapChange() {
        completedSwap = true;
        saveDataVariable.CompleteInteraction();
        if (inputOutputItemExchange.outputInventoryObject)
            inventoryController.PickupItem(inputOutputItemExchange.outputInventoryObject);
        UpdateMapScene();
    }
    private void UpdateMapScene() {
        switch (inputOutputItemExchange.mapObjectChange) {
            case InteractType.ToggleVisibility:
                foreach (GameObject obj in inputOutputItemExchange.inputMapObject) {
                    if (obj.activeSelf) {
                        if (obj.GetComponent<Animator>())
                            Destroy(obj.GetComponent<Animator>());
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
