using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryMergeCombinations {
    public Sprite inputSprite1;
    public Sprite inputSprite2;
    public Sprite resultSprite;
    public string mergeComment;
}
public class InventoryController : MonoBehaviour
{
    public Sprite uiMask;
    public Sprite handIcon;
    public GameObject dragCancelLayer;
    #region Private Variables
    [SerializeField] private Sprite selectedSlotSprite;
    [SerializeField] private string incorrectMergeComment = "Not sure how I can put those together.";
    [SerializeField] private GameObject[] inventorySlots;
    private int currentlySelectedSlotIndex = 0;
    private InventoryInputActions inventoryInputActions;
    [SerializeField] private TextBoxController textBoxController;
    [SerializeField] private List<InventoryMergeCombinations> inventoryMergeCombinations;
    private int retardedNetMouseChange = 0;
    #endregion
    private void Awake() {
        inventoryInputActions = new InventoryInputActions();
    }
    private void OnEnable() {
        inventoryInputActions.Enable();
    }
    private void OnDisable() {
        inventoryInputActions.Disable();
    }

    private void Start()   
    {
        inventoryInputActions.Inventory.ScrollItems.performed += ctx => InventoryScroll(ctx.ReadValue<float>());
        SetSelectedSlotIconToCurrentSelected(0, 0);
    }
    private void InventoryScroll(float scrollDelta) {
        if (scrollDelta > 0f) {
            retardedNetMouseChange -= 3;
        } else {
            retardedNetMouseChange++;
        }
        if (Mathf.Abs(retardedNetMouseChange) == 2) {
            int prevSelectedSlotIndex = currentlySelectedSlotIndex;
            do {
                currentlySelectedSlotIndex = (currentlySelectedSlotIndex + retardedNetMouseChange / 2);
            }
            while (currentlySelectedSlotIndex != -1 && currentlySelectedSlotIndex != inventorySlots.Length && inventorySlots[currentlySelectedSlotIndex].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite == uiMask);
            currentlySelectedSlotIndex = Mathf.Clamp(currentlySelectedSlotIndex, 0, inventorySlots.Length - 1);
            if (inventorySlots[currentlySelectedSlotIndex].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite == uiMask)
                currentlySelectedSlotIndex = prevSelectedSlotIndex;
            SetSelectedSlotIconToCurrentSelected(prevSelectedSlotIndex, currentlySelectedSlotIndex);
            retardedNetMouseChange = 0;
        }
    }
    private void SetSelectedSlotIconToCurrentSelected(int prevSelectedSlotIndex, int curSelectedSlotIndex) {
        inventorySlots[prevSelectedSlotIndex].GetComponent<Image>().sprite = uiMask;
        inventorySlots[curSelectedSlotIndex].GetComponent<Image>().sprite = selectedSlotSprite;
    }

    public void SetSelectedSlotIndex(int selectedSlot) {
        if (!inventorySlots[selectedSlot].GetComponent<Image>().sprite == uiMask) {
            SetSelectedSlotIconToCurrentSelected(currentlySelectedSlotIndex, selectedSlot);
            currentlySelectedSlotIndex = selectedSlot;
        }
    }
    public Sprite GetCurrentSelection() {
        return inventorySlots[currentlySelectedSlotIndex].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite;
    }
    public void PickupItem(Sprite inventoryObject) {
        for (int i = 0; i < inventorySlots.Length; i++) {
            if (inventorySlots[i].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite == uiMask) {
                inventorySlots[i].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = inventoryObject;
                return;
            }
        }
    }
    public void DestroyCurrentSelection() {
         inventorySlots[currentlySelectedSlotIndex].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = uiMask;
    }

    public bool IsHandSelection() {
        return currentlySelectedSlotIndex == 0;
    }

    public void SetToHandSelection() {
        SetSelectedSlotIconToCurrentSelected(currentlySelectedSlotIndex, 0);
        currentlySelectedSlotIndex = 0;
    }

    public void MergeItems(int fromSlotIndex, int toSlotIndex) {
        GameObject fromItem = inventorySlots[fromSlotIndex].transform.Find("ItemImage").gameObject;
        GameObject toItem = inventorySlots[toSlotIndex].transform.Find("ItemImage").gameObject;
        Sprite spriteFrom = fromItem.GetComponent<Image>().sprite;
        Sprite spriteTo = toItem.GetComponent<Image>().sprite;

        if (fromSlotIndex == toSlotIndex || toSlotIndex == 0) {
            fromItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 
            return;
        }
        
        if (spriteTo == uiMask) {
            fromItem.GetComponent<Image>().sprite = spriteTo;
            toItem.GetComponent<Image>().sprite = spriteFrom;  
            fromItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
        else {
            int combinationIndex = -1;
            for (int i = 0; i < inventoryMergeCombinations.Count; i++) {
                Sprite spriteCheckOne = inventoryMergeCombinations[i].inputSprite1;
                Sprite spriteCheckTwo = inventoryMergeCombinations[i].inputSprite2;
                bool hasOne = spriteFrom == spriteCheckOne || spriteTo == spriteCheckOne;
                bool hasTwo = spriteFrom == spriteCheckTwo || spriteTo == spriteCheckTwo;
                if (hasOne && hasTwo) {
                    combinationIndex = i;
                }
            }
            if (combinationIndex != -1) {
                StartCoroutine(textBoxController.DisplayDialogue(inventoryMergeCombinations[combinationIndex].mergeComment));
                toItem.GetComponent<Image>().sprite = inventoryMergeCombinations[combinationIndex].resultSprite;
                fromItem.GetComponent<Image>().sprite = uiMask;
                fromItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;  
            } else {
                StartCoroutine(textBoxController.DisplayDialogue(incorrectMergeComment));
                fromItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;  
            }
        }
        SetToHandSelection();
    }
}
