using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
        player.ZeroVelocity();
    }

    public override void UpdateState()
    {
        player.SetVelocityX(InputManager.MovementInput().x * 10);
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (InputManager.MovementInput().magnitude <= 0)
        {
            return PlayerStateMachine.EPlayerState.Idle;
        }

        return StateKey;
    }

    public override void AnimationFinishTrigger()
    {
        throw new System.NotImplementedException();
    }
}
