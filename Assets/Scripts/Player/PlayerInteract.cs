using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;

    [SerializeField] private Collider2D interactCollider;

    private bool canInteract = true;

    private InputAction interactAction;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
        DisableCollider();
    }

    private void Start()
    {
        interactAction = InputActionsManager.Instance.GetInteractAction();
        interactAction.Enable();
        interactAction.performed += InteractPerformedInputHandler;
    }

    private void InteractPerformedInputHandler(InputAction.CallbackContext context)
    {
        if (myRigidbody2D.velocity == Vector2.zero && canInteract)
        {
            canInteract = false;
            Interact();
        }
    }

    public void Interact()
    {
        myAnimator.SetTrigger("interact");
    }

    private void EnableCollider()
    {
        canInteract = false;
        interactCollider.enabled = true;
    }

    private void DisableCollider()
    {
        canInteract = true;
        interactCollider.enabled = false;
    }

    private void OnDestroy()
    {
        interactAction.performed -= InteractPerformedInputHandler;
        interactAction.Disable();
    }
}
