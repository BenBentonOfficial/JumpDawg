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
        if (Mathf.Abs(InputManager.MovementInput().x) > 0)
            return PlayerStateMachine.EPlayerState.Move;
        
        if (player.OnPlatform() && InputManager.MovementInput().y < 0 && InputManager.instance.Jump.Queued)
            return PlayerStateMachine.EPlayerState.PlatformFall;

        if (InputManager.instance.Jump.Queued)
            return PlayerStateMachine.EPlayerState.Jump;
        
        return StateKey;
    }
}
