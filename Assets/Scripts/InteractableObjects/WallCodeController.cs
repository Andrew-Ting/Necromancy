using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCodeController : MonoBehaviour
{
    [SerializeField] private int codeIndex;
    [SerializeField] private WallCodePersistentData wallCodePersistentData;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = wallCodePersistentData.GetHieroglyphAtIndex(codeIndex);
    }

}
