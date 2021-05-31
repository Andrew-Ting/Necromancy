using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GameObject inventoryUI;
    private GameObject dragCancelLayer;
    private Sprite uiMask;
    private Sprite handIcon;
    private Canvas inventoryUICanvas;
    private CanvasGroup objectCanvas;
    private RectTransform rectTransform;
    private bool isDraggable;
    private void Awake() {
        objectCanvas = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        inventoryUICanvas = inventoryUI.GetComponent<Canvas>();
        uiMask = transform.parent.parent.GetComponent<InventoryController>().uiMask;
        handIcon = transform.parent.parent.GetComponent<InventoryController>().handIcon;
        dragCancelLayer = transform.parent.parent.GetComponent<InventoryController>().dragCancelLayer;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        if (eventData.pointerDrag.GetComponent<Image>().sprite == handIcon)
            return;
        Debug.Log("OnBeginDrag");
        objectCanvas.alpha = .6f;
        objectCanvas.blocksRaycasts = false;
        dragCancelLayer.SetActive(true);
        if (eventData.pointerDrag && eventData.pointerDrag.GetComponent<Image>().sprite != uiMask)
            isDraggable = true;
    }
    public void OnDrag(PointerEventData eventData) {
        if (isDraggable) {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta / inventoryUICanvas.scaleFactor;
        }
    }
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        objectCanvas.alpha = 1f;
        objectCanvas.blocksRaycasts = true;
        dragCancelLayer.SetActive(false);
        isDraggable = false;
    }

    public void ReturnToOriginalPosition() {
        transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
