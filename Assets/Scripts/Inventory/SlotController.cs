using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotController : MonoBehaviour, IPointerDownHandler, IDropHandler
{
    public int currentSlotIndex;
    [SerializeField] private InventoryController inventoryController;
    private GameObject inventoryObject;

    private Sprite uiMask;
    private Sprite handIcon;
    private void Start() {
        inventoryObject = transform.Find("ItemImage").gameObject;
        uiMask = transform.parent.GetComponent<InventoryController>().uiMask;
        handIcon = transform.parent.GetComponent<InventoryController>().handIcon;
    }
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag && eventData.pointerDrag.GetComponent<Image>().sprite != uiMask && eventData.pointerDrag.GetComponent<Image>().sprite != handIcon) {
            inventoryController.MergeItems(eventData.pointerDrag.transform.parent.GetComponent<SlotController>().currentSlotIndex, currentSlotIndex);
        }
    }
}
