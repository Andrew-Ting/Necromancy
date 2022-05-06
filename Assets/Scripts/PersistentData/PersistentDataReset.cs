using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentDataReset : MonoBehaviour
{
    [SerializeField] private List<InteractionPersistentData> gameData = null;
    [SerializeField] private InventoryPersistentData inventoryPersistentData = null;
    [SerializeField] private WallCodePersistentData wallCodePersistentData = null;
    public void Awake() {
        Button thisButton = GetComponent<Button>();
       thisButton.onClick.AddListener(() => {
        ResetData();
       });
    }

    void ResetData() {
        foreach (InteractionPersistentData data in gameData) {
            data.ResetData();
        }
        inventoryPersistentData.ResetData();
        wallCodePersistentData.ResetData();
    }
}
