using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [Header("Input Actions")] 
    [SerializeField] private InputActionReference movement;

    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference dash;
    //[SerializeField] private InputActionReference ability;
    
    public Action jumpAction;
    public Action jumpActionCancel;
    public Action dashAction;
    //public Action abilityAction;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        jump.action.performed += Jump;
        jump.action.canceled += JumpCancel;
        dash.action.performed += Dash;
    }

    public static Vector2 MovementInput()
    {
        return instance.movement.action.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        jumpAction?.Invoke();
    }

    private void JumpCancel(InputAction.CallbackContext context)
    {
        jumpActionCancel?.Invoke();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        dashAction?.Invoke();
    }
}
