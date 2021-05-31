using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReachable : MonoBehaviour
{
    public bool isInTheWay = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) => isInTheWay = true;
    private void OnTriggerExit2D(Collider2D other) => isInTheWay = false;
}
