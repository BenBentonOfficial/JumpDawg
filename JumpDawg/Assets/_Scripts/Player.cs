using System;
using UnityEngine;

public class Player : Entity
{
    public PlayerStateMachine StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = GetComponent<PlayerStateMachine>();
        StateMachine.Initialize(this, _rb, _animator);

    }
}
