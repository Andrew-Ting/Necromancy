using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Interaction", menuName="Interaction Data Piece")]
public class InteractionPersistentData : ScriptableObject
{
    private bool interactionOccurred = false;

    void ForceSerialization() { // you can call this function after changing scriptableobject state if you want serialized variable state to persist between scenes
        #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
    private void OnEnable()
     {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
     }
    public void CompleteInteraction() {
        interactionOccurred = true;
    }
    public void ResetData() {
        interactionOccurred = false;
    }
    public bool IsCompleted() {
        return interactionOccurred;
    }
}
