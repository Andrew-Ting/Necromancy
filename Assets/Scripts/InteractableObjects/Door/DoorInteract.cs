using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorInteract : Interactable
{
    public Action <bool> UpdateDoorOpenness; 
    [SerializeField] private Sprite doorClosed;
    [SerializeField] private Sprite doorOpened;
    [SerializeField] private GameObject blockingPlayerColliderObject;
    [SerializeField] private GameObject opposingSideOpenTrigger;
    private bool opened = false;
    [SerializeField] private string closedDoorSortingLayer;
    private void Start() {
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
            opened = true;
        }
    }
    public void UpdateOpenness(bool openness) => opened = openness;
}
