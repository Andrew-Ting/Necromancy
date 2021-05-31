using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField] private float walkSpeed;
    private Animator animator; 
    private Rigidbody2D myRigidBody;
    private PlayerInputControls playerInputControls;
    [SerializeField] private TextBoxController textBoxController;
    private bool freezeCharacter = false;
    private Interactable latestObjectInteractable;
    private InventoryController inventoryController;
    #endregion
    private void Awake() {
        playerInputControls = new PlayerInputControls();
    }
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        textBoxController.dialogueBoxDisplaying += textDisplaying => {freezeCharacter = textDisplaying; animator.SetBool("isWalking", false);};
    }
    private void OnEnable() {
        playerInputControls.Enable();
    }
    private void OnDisable() {
        playerInputControls.Disable();
    }

    private void OnMouseDown() {
        Debug.Log("HI");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!freezeCharacter) {
            float deltax = playerInputControls.Player.WalkHorizontal.ReadValue<float>();
            float deltay = playerInputControls.Player.WalkVertical.ReadValue<float>();
            Vector3 moveChange = new Vector3(deltax, deltay, 0);
            if (moveChange != Vector3.zero) {
                animator.SetBool("isWalking", true);
                animator.SetFloat("moveX", deltax);
                animator.SetFloat("moveY", deltay);
                MoveCharacter(moveChange);
            } else {
                animator.SetBool("isWalking", false);
            }
        }
    }
    void MoveCharacter(Vector3 displacement) {
        myRigidBody.MovePosition(
            transform.position + displacement * walkSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D interactableObject) {
        Debug.Log("Entered interact range of " + interactableObject.gameObject.name);
        if (interactableObject.gameObject.tag == "Interactable") {
            latestObjectInteractable = interactableObject.gameObject.GetComponent<Interactable>();
            playerInputControls.Player.Interact.performed += InteractLatestObjectResponse;
        }
    }
    private void OnTriggerExit2D(Collider2D interactableObject) {
        Debug.Log("Exited interact range!");
        if (interactableObject.gameObject.tag == "Interactable") {
            latestObjectInteractable = interactableObject.gameObject.GetComponent<Interactable>();
            playerInputControls.Player.Interact.performed -= InteractLatestObjectResponse;
        }
    }
    public void InteractLatestObjectResponse(InputAction.CallbackContext ctx) {
        latestObjectInteractable.InteractObjectResponse();
    }
}
