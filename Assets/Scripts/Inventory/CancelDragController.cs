using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CancelDragController : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag) {
            eventData.pointerDrag.GetComponent<InventoryItemController>().ReturnToOriginalPosition();
        }
    }
}
