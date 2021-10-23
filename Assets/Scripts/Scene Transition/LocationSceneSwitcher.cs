using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocationSceneSwitcher : MonoBehaviour
{
    private enum LocationSceneType {
        LowFloorSkeleton,
        MidFloorSkeleton,
        HighFloorSkeleton,
        SewerSkeleton
    };

    [SerializeField] 
    private LocationSceneType destinationScene = LocationSceneType.LowFloorSkeleton;
    private GameObject helperPanel;
    private TextBoxController textBoxController;
    private bool isInSceneMoveRange = false;

    private Animator screenTransition;
    [SerializeField] private float screenTransitionTime = 2f;
    [SerializeField] private bool interactMovement = false; // when this is false, player is automatically moved to next scene on enter trigger. Otherwise, they need to finish a text box.
    #region Spawn Position Setting Vars 
    // these variables set where the player spawns in the current scene right before they leave it (for when they come back)
    [SerializeField] private GlobalData.Floor fromFloorType = GlobalData.Floor.NotApplicable; 
    [SerializeField] private Vector3 spawnPosInFromFloorType;
    #endregion
    private IEnumerator loadScene()
    {
        if (fromFloorType != GlobalData.Floor.NotApplicable)
           GlobalData.spawnPosition[(int)fromFloorType] = spawnPosInFromFloorType;
        screenTransition.SetTrigger("start");
        helperPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(screenTransitionTime);
        SceneManager.LoadScene(destinationScene.ToString());
        yield return new WaitForSecondsRealtime(screenTransitionTime);
        helperPanel.SetActive(false);
    }
    void OnTriggerEnter2D() {
        if (!interactMovement || GlobalData.SpecialInteractionData.unlockedSewers)
            StartCoroutine(loadScene());
        isInSceneMoveRange = true;
    }
    void OnTriggerExit2D() {
        isInSceneMoveRange = false;
    }
    void Awake() {
        textBoxController = FindObjectOfType<TextBoxController>();
        textBoxController.dialogueBoxDisplaying += StartSceneSwitchAfterDialogue;
    }
    void Start() {
        helperPanel = GameObject.Find("SwipeToBlackPanel");
        screenTransition = helperPanel.GetComponent<Animator>();
    }
    void StartSceneSwitchAfterDialogue(bool dialogueBoxDisplaying) {
        if (!dialogueBoxDisplaying && isInSceneMoveRange) {
            GlobalData.SpecialInteractionData.unlockedSewers = true; // definitely change this hack to a scriptable object if more flexibility is needed; for now, this will do
            StartCoroutine(loadScene());
        }
    }
}