using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorInteract : Interactable
{
    public Action <bool> UpdateDoorOpenness; 
    [SerializeField] private Sprite doorClosed = null;
    [SerializeField] private Sprite doorOpened = null;
    [SerializeField] private GameObject blockingPlayerColliderObject = null;
    [SerializeField] private GameObject opposingSideOpenTrigger = null;
    private bool opened = false;
    [SerializeField] private string closedDoorSortingLayer = "";
    [SerializeField] private string openDoorSortingLayer = "";
    new private void Start() {
        opposingSideOpenTrigger.GetComponent<DoorInteract>().UpdateDoorOpenness += UpdateOpenness;
    }
    public override void InteractObjectResponse() {
        SpriteRenderer doorObjectRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        if (opened && !blockingPlayerColliderObject.GetComponent<DoorReachable>().isInTheWay) {
            doorObjectRenderer.sprite = doorClosed;
            doorObjectRenderer.sortingLayerName = closedDoorSortingLayer;
            blockingPlayerColliderObject.GetComponent<BoxCollider2D>().isTrigger = false;
            opened = false;
        } else if (!opened) {
            doorObjectRenderer.sprite = doorOpened;
            blockingPlayerColliderObject.GetComponent<BoxCollider2D>().isTrigger = true;
            doorObjectRenderer.sortingLayerName = openDoorSortingLayer;
            opened = true;
        }
    }
    public void UpdateOpenness(bool openness) => opened = openness;
}
