using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDragDisable : MonoBehaviour
{
    [SerializeField] private TextBoxController textBoxController = null;
    // Start is called before the first frame update
    void Start()
    {
        textBoxController.dialogueBoxDisplaying += textDisplaying => gameObject.GetComponent<CanvasGroup>().blocksRaycasts = textDisplaying;
    }


}
