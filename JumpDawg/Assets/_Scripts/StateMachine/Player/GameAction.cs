using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class GameAction
{
    [SerializeField] private InputActionReference inputAction;
    public Action perform;
    public Action cancel;
    
    public void Setup(float queueTime)
    {
        _queueTime = queueTime;

        inputAction.action.performed += PerformAction;
        inputAction.action.canceled += CancelAction;
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
       InputManager.instance.SetInputConsumeTimer(_queueTime);
    }

    public void Consume() => _queued = false;

}
