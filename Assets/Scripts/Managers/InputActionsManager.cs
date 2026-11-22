using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionsManager : MonoBehaviour
{
    public static InputActionsManager Instance {  get; private set; }

    private PlayerInputActions inputActions;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            inputActions = new();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public InputAction GetMoveAction()
    {
        return inputActions.Player.Move;
    }

    public InputAction GetInteractAction()
    {
        return inputActions.Player.Interact;
    }

    public InputAction GetCutAction()
    {
        return inputActions.Minigame.Cut;
    }
}
