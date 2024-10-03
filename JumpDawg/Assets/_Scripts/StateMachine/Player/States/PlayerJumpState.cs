using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    private bool jumpCanceled = false;

    private void EndJump() => jumpCanceled = true;

    public override void EnterState()
    {
        base.EnterState();
        jumpCanceled = false;
        InputManager.instance.Jump.cancel += EndJump;
        InputManager.instance.Jump.Consume();
        
        player.SetVelocityY(player.JumpForce);
    }

    public override void ExitState()
    {
        base.ExitState();
        player.SetVelocityY(0);
        InputManager.instance.Jump.cancel -= EndJump;
    }

    public override void UpdateState()
    {
       base.UpdateState();
       
       player.SetVelocityX(InputManager.MovementInput().x * player.MoveSpeed * 0.8f);
       player.SetGravity(RB.gravityScale += Time.deltaTime * 5f);
       
       player.CheckFlip();
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (player.Velocity().y <= 0 || jumpCanceled)
            return PlayerStateMachine.EPlayerState.Fall;

        return StateKey;
    }
}
