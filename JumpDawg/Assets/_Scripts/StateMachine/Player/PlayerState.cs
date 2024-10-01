using UnityEngine;

public class PlayerState : State<PlayerStateMachine.EPlayerState>
{
    protected PlayerState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
        player = entity;
    }

    protected Player player;

    public override void EnterState()
    {
        // animator must have bool parameter w/ same name as state key
        Animator.SetBool(StateKey.ToString(), true);
        animEnded = false;
    }

    public override void ExitState()
    {
        Animator.SetBool(StateKey.ToString(), false);
    }

    public override void UpdateState()
    {
        //throw new System.NotImplementedException();
    }

    public override void PhysicsUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimationFinishTrigger()
    {
        animEnded = true;
    }
}
