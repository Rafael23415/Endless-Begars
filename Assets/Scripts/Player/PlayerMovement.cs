using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;

    [Header("Stats")]
    [SerializeField] private float velocity;
    private Vector2 currentVelocity;

    private InputAction moveAction;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        moveAction = InputActionsManager.Instance.GetMoveAction();
        moveAction.Enable();
        moveAction.performed += MovePerformedInputHandler;
        moveAction.canceled += MoveCanceledInputHandler;
    }

    private void MovePerformedInputHandler(InputAction.CallbackContext context)
    {
        currentVelocity = context.ReadValue<Vector2>() * velocity;
        Flip(context.ReadValue<Vector2>().x);
    }

    private void MoveCanceledInputHandler(InputAction.CallbackContext context)
    {
        currentVelocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = currentVelocity;
        myAnimator.SetBool("isWalking", myRigidbody2D.velocity != Vector2.zero);
    }

    private void Flip(float direction)
    {
        if (direction > 0 && transform.right.x == -Vector2.one.x || direction < 0 && transform.right.x == Vector2.one.x)
        {
            transform.right *= -1;
        }
    }

    public void DisablePlayerController()
    {
        moveAction.Disable();
    }

    public void UpgradeAxe(int level)
    {
        int axeMultiplier = (int)Mathf.Pow(2, level) / 2;
        ResourceManager.Instance.ChangeMultiplier(axeMultiplier);
    }

    private void OnDestroy()
    {
        moveAction.performed -= MovePerformedInputHandler;
        moveAction.canceled -= MoveCanceledInputHandler;
        moveAction.Disable();
    }
}
