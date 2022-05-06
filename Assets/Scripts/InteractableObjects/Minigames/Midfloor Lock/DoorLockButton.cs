using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DoorLockButton : MonoBehaviour
{
    private DoorLockMinigameController doorLockMinigameController;
    [SerializeField] private int hieroglyphNumber;
    // Start is called before the first frame update
    void Start()
    {
        doorLockMinigameController = transform.parent.parent.gameObject.GetComponent<DoorLockMinigameController>();
        Button thisButton = GetComponent<Button>();
        if (thisButton != null) {
            thisButton.onClick.AddListener(() => {
                doorLockMinigameController.CodeInputted(hieroglyphNumber);
            });
        }
    }
}
