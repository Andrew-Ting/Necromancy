using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
class MinigameResultDetails {
    public int waitInSeconds = 0;
    public GameObject inputMapObject = null; 
    public InteractType mapObjectChange = InteractType.None;
}
public class MinigameInteraction : Interactable
{
    [SerializeField] private GameObject minigameModal;
    [SerializeField] private InteractionPersistentData minigameProgress = null;
    private MinigameController minigameController;
    private bool isMinigameCompleted = false;
    private bool isTextBoxDisplaying = false;
    #region 
    [SerializeField] private List<MinigameResultDetails> onSuccessEffect;
    [SerializeField] private List<MinigameResultDetails> onFailureEffect;
    [SerializeField] private List<MinigameResultDetails> onSceneLoadEffect;
    #endregion

    void Awake() {
        textBoxController = FindObjectOfType<TextBoxController>();
        minigameController = FindObjectOfType<MinigameController>();
    }
    void Start() {
        textBoxController.dialogueBoxDisplaying += (dialogueState) => StartCoroutine(SetTextboxDisplayingState(dialogueState));
        isMinigameCompleted = minigameProgress.IsCompleted();
        if (isMinigameCompleted)
            handleSceneUpdates("Start");
    }
    public override void InteractObjectResponse() {
        if (!isMinigameCompleted && !isTextBoxDisplaying) {
            minigameModal.SetActive(true);
            minigameController.freezeCharacter();
        }
    }
    public void OnSuccess(string successDialogueMessage) {
        if (successDialogueMessage != "")
            StartCoroutine(textBoxController.DisplayDialogue(successDialogueMessage));
        isMinigameCompleted = true;
        if (!SuccessSwitchesScene()) // hack to prevent immediate transition when new scene is unlocked
            minigameProgress.CompleteInteraction(); 
        minigameModal.SetActive(false);
        handleSceneUpdates("Success");
        minigameController.unfreezeCharacter();
    }
    public void OnFailure(string failureDialogueMessage) {
        if (failureDialogueMessage != "")
            StartCoroutine(textBoxController.DisplayDialogue(failureDialogueMessage));
        minigameModal.SetActive(false);
        handleSceneUpdates("Failure");
        minigameController.unfreezeCharacter();
    }
    private bool SuccessSwitchesScene() {
        for (int i = 0; i < onSuccessEffect.Count; i++) {
            if (onSuccessEffect[i].inputMapObject.GetComponent<LocationSceneSwitcher>())
                return true;
        }
        return false;
    }
    IEnumerator UpdateMapScene(MinigameResultDetails sceneChange, string successOrFailure) {
        GameObject obj = sceneChange.inputMapObject;
        yield return new WaitForSecondsRealtime(sceneChange.waitInSeconds);
        switch (sceneChange.mapObjectChange) {
            case InteractType.ToggleVisibility:
                    if (obj.activeSelf) {
                        if (obj.GetComponent<Animator>())
                            Destroy(obj.GetComponent<Animator>());
                        if (obj.GetComponent<SpriteRenderer>()) 
                            obj.GetComponent<SpriteRenderer>().sprite = null;
                        if (obj.GetComponent<CircleCollider2D>())
                            Destroy(obj.GetComponent<CircleCollider2D>());
                        if (obj.GetComponent<CapsuleCollider2D>())
                            Destroy(obj.GetComponent<CapsuleCollider2D>());    
                        if (obj.GetComponent<BoxCollider2D>())
                            Destroy(obj.GetComponent<BoxCollider2D>());
                    }
                    else    
                        obj.SetActive(true);
                break;
            case InteractType.Animate:
                    if (successOrFailure == "Success")
                        obj.GetComponent<Animator>().SetBool("Success", true);
                    else    
                        obj.GetComponent<Animator>().SetTrigger("Failure");
                break;
            case InteractType.None:
                break;
        }
    }
    IEnumerator SetTextboxDisplayingState(bool dialogueState) {
        yield return null; // wait one frame before setting dialogue box display state to prevent race condition of textbox display var and minigame modal popup condition check on F key press
        isTextBoxDisplaying = dialogueState;
    }
    private void handleSceneUpdates(string resultType) {
        if (resultType == "Success") {
            for (int i = 0; i < onSuccessEffect.Count; i++) {
                StartCoroutine(UpdateMapScene(onSuccessEffect[i], "Success"));
            }
        } else if (resultType == "Failure") {
            for (int i = 0; i < onFailureEffect.Count; i++) {
                StartCoroutine(UpdateMapScene(onFailureEffect[i], "Failure"));
            }
        } else {
            for (int i = 0; i < onSceneLoadEffect.Count; i++) {
                StartCoroutine(UpdateMapScene(onSceneLoadEffect[i], isMinigameCompleted ? "Success" : "Failure"));
            }
        }
    }
}
