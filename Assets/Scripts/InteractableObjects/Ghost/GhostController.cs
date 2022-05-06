using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [System.Serializable]
    private class GhostMinigame {
        private int checkpointNum;
        private InventoryPersistentData isMinigameCompleted;
    } 
    [SerializeField] private int ghostSpeed = 4;
    [SerializeField] private List<Vector3> ghostWaitPoints;
    [SerializeField] private List<GhostMinigame> MinigamePoints;
    int curWaitPointNum;
    private bool midFlying;

    void Start()
    {
        curWaitPointNum = GlobalData.SpecialInteractionData.ghostProgress;
        transform.position = ghostWaitPoints[curWaitPointNum];
    }

    void OnDrawGizmosSelected() {
        if (ghostWaitPoints.Count > 0) {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(ghostWaitPoints[0], new Vector3(.3f, .3f, .3f));
            for (int i = 1; i < ghostWaitPoints.Count; i++)
            {
                Gizmos.DrawLine(ghostWaitPoints[i-1], ghostWaitPoints[i]);
                Gizmos.DrawCube(ghostWaitPoints[i], new Vector3(.3f, .3f, .3f));
            }    
        }
    }

    void OnTriggerEnter2D(Collider2D interactableObject) {
        if (interactableObject.gameObject.tag == "Player" && GlobalData.SpecialInteractionData.ghostProgress < ghostWaitPoints.Count - 1) {
            midFlying = true;
            GlobalData.SpecialInteractionData.ghostProgress++;
            curWaitPointNum = GlobalData.SpecialInteractionData.ghostProgress;
            StartCoroutine(FlyTo(GlobalData.SpecialInteractionData.ghostProgress));
        }
    }
    IEnumerator FlyTo(int checkpointIndex) {
        Vector3 vectorOfFlying = ghostWaitPoints[checkpointIndex] - ghostWaitPoints[checkpointIndex - 1];
        if (vectorOfFlying.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        float travelProgress = 0;
        while (travelProgress < 1) {
            transform.position = Vector3.Lerp(ghostWaitPoints[checkpointIndex - 1], ghostWaitPoints[checkpointIndex], travelProgress);
            travelProgress += ghostSpeed / (vectorOfFlying.magnitude * 10);
            travelProgress = Mathf.Clamp(travelProgress, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
        midFlying = false;
    }
    
}
