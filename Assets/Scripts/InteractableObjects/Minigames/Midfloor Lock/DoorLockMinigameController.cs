using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockMinigameController : MonoBehaviour
{
    private int correctCount = 0; 
    private int inputCount = 0;
    [SerializeField] private MinigameInteraction minigameInteraction;
    [SerializeField] private WallCodePersistentData wallCodePersistentData;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }
    public void CodeInputted(int hieroglyph) {
        if (wallCodePersistentData.GetHieroglyphIndexAtIndex(3 - inputCount) == hieroglyph) {
            Debug.Log("CORRECT CHOSEN");
            correctCount++;
        }
        else Debug.Log("WRONG CHOSEN. EXPECTED " + wallCodePersistentData.GetHieroglyphIndexAtIndex(3 - inputCount) + " GOT " + hieroglyph);
        inputCount++;
        if (correctCount == 4) {
            minigameInteraction.OnSuccess("CORRECT!!!!!");
        }
        else if (inputCount == 4) {
            minigameInteraction.OnFailure("WRONG!!!!!");
            correctCount = 0;
            inputCount = 0;
        }
    }
}
