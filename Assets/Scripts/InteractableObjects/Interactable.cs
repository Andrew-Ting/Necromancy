using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    protected InventoryController inventoryController;
    protected TextBoxController textBoxController;
    private void Awake() {
        textBoxController = GameObject.FindWithTag("TextBox").GetComponent<TextBoxController>();
    }
    protected void Start()
    {
        inventoryController = GameObject.FindWithTag("Inventory").GetComponent<InventoryController>();
    }
    public abstract void InteractObjectResponse();
}
