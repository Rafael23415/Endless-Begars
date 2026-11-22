using UnityEngine;
using UnityEngine.InputSystem;

public class PlanksMinigame : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    private InputAction cutAction;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.velocity = Vector2.right * horizontalSpeed;
    }

    private void Start()
    {
        cutAction = InputActionsManager.Instance.GetCutAction();
        cutAction.Enable();
        cutAction.performed += InputCutPerformed;
    }

    private void InputCutPerformed(InputAction.CallbackContext context)
    {
        myRigidbody2D.velocity = Vector2.down * verticalSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Boundaries"))
        {
            myRigidbody2D.velocity *= -1;
        }
        if (other.collider.CompareTag("CutPoint"))
        {
            myRigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnDestroy()
    {
        cutAction.performed -= InputCutPerformed;
        cutAction.Disable();
    }
}
