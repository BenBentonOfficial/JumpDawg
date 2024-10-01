using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [Header("Input Actions")] 
    [SerializeField] private InputActionReference movement;
    //[SerializeField] private InputActionReference jump;
    //[SerializeField] private InputActionReference dash;
    //[SerializeField] private InputActionReference ability;

    //public Action jumpAction;
    //public Action jumpActionCancel;
    //public Action dashAction;
    //public Action abilityAction;

    public GameAction Jump;
    public GameAction Dash;

    private float inputConsumeTimer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        Jump.Setup(0.1f);
        Dash.Setup(0.1f);
    }

    private void Update()
    {
        inputConsumeTimer -= Time.deltaTime;

        if (inputConsumeTimer <= 0)
        {
            Jump.Consume();
            Dash.Consume();
        }

        Debug.Log(MovementInput());
    }

    public static Vector2 MovementInput()
    {
        return instance.movement.action.ReadValue<Vector2>();
    }

    public void SetInputConsumeTimer(float time) => inputConsumeTimer = time;

    // private void Jump()
    // {
    //     jumpAction?.Invoke();
    // }
    //
    // private void JumpCancel()
    // {
    //     jumpActionCancel?.Invoke();
    // }
    //
    // private void Dash()
    // {
    //     dashAction?.Invoke();
    // }
}
