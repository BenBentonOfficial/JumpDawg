using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.ZeroVelocity();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    
    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (InputManager.MovementInput().magnitude > 0)
            return PlayerStateMachine.EPlayerState.Move;

        if (InputManager.instance.Jump.Queued)
            return PlayerStateMachine.EPlayerState.Jump;
        
        return StateKey;
    }
}
