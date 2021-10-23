using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLayerDetection : MonoBehaviour
{
    [SerializeField] private string doorSortingLayer;
    // this class is used to switch the layer of the door if it detects the player above or below it
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.gameObject.GetComponent<PlayerController>() != null) {
             SpriteRenderer doorObjectRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
             doorObjectRenderer.sortingLayerName = doorSortingLayer;
        }
    }

  
}
