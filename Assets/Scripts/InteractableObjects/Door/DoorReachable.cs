using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReachable : MonoBehaviour
{
    public bool isInTheWay = false;
    [SerializeField] private string initialSortingLayer = "";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) => isInTheWay = true;
    private void OnTriggerExit2D(Collider2D other) => isInTheWay = false;
    void Start() {
        SpriteRenderer doorObjectRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        doorObjectRenderer.sortingLayerName = initialSortingLayer;
    }
}
