using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class GameAction
{
    private InputManager inputManager;
    [SerializeField] private InputActionReference inputAction;
    public Action perform;
    public Action cancel;
    
    public void Setup(InputManager manager ,float queueTime)
    {
        inputManager = manager;
        _queueTime = queueTime;

        inputAction.action.performed += PerformAction;
        inputAction.action.canceled += CancelAction;

        perform += Queue;
    }

    public void PerformAction(InputAction.CallbackContext context)
    {
        perform?.Invoke();
    }

    public void CancelAction(InputAction.CallbackContext context)
    {
        cancel?.Invoke();
    }

    private bool _queued;
    private float _queueTime;

    public bool Queued => _queued;
    public float QueueTime => _queueTime;

    public void Queue()
    {
        _queued = true; 
       inputManager.SetInputConsumeTimer(_queueTime);
    }

    public void Consume() => _queued = false;

}
