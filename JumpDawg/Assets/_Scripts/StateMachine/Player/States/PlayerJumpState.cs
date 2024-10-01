using UnityEngine;

public class PlayerJumpState : State<PlayerStateMachine.EPlayerState>
{
    public PlayerJumpState(PlayerStateMachine.EPlayerState key, Entity entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimationFinishTrigger()
    {
        throw new System.NotImplementedException();
    }
}
