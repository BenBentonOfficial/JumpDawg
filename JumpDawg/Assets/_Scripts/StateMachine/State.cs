using System;
using UnityEngine;

public abstract class State<EState> where EState : Enum
{
    protected State(EState key, Rigidbody2D rb, Animator anim)
    {
        StateKey = key;
        RB = rb;
        Animator = anim;
    }

    public EState StateKey { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Animator { get; private set; }

    protected float stateTimer;
    protected bool animEnded;

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void PhysicsUpdate();
    public abstract EState GetNextState();
    public abstract void AnimationFinishTrigger();

}
