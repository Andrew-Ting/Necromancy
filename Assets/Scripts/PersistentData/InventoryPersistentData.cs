using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Inventory Data", menuName="Inventory Data")]
public class InventoryPersistentData : ScriptableObject
{
    private List<Sprite> inventoryLayout = new List<Sprite>();
    private int selectedObject = 0;
    [SerializeField] private Sprite handSelect = null;
    [SerializeField] private Sprite uiMask = null;
    [SerializeField] private int inventorySlotCount = 8;
    public void SetInventory(List<Sprite> newInventoryLayout) {
        inventoryLayout = newInventoryLayout;
    }
    public void SetSelectedItem(int newSelectedObject) {
        selectedObject = newSelectedObject;
    }
    public List<Sprite> GetInventory() {
        return inventoryLayout;
    }
    public int GetSelectedItem() {
        return selectedObject;
    }
    public void ResetData() {
        inventoryLayout = new List<Sprite>();
        inventoryLayout.Add(handSelect);
        for (int i = 1; i < inventorySlotCount; i++)
            inventoryLayout.Add(uiMask);
        selectedObject = 0;
    }
}
