using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    private float coyoteTimer;

    public override void EnterState()
    {
        base.EnterState();
        stateTimer = 1;
        coyoteTimer = 0;

        // if the last state was Move, start coyote time
        if (player.StateMachine.GetLastState().StateKey == PlayerStateMachine.EPlayerState.Move)
        {
            coyoteTimer = 0.1f;
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        player.SetGravity(player.Gravity);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocityX((player.MoveSpeed * 0.8f) * InputManager.MovementInput().x);

        player.SetGravity(RB.gravityScale += Time.deltaTime * 3f);

        if (coyoteTimer > 0)
        {
            coyoteTimer -= Time.deltaTime;
        }
        
        player.CheckFlip();

    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (player.touchingGround)
            return PlayerStateMachine.EPlayerState.Idle;

        if (!player.touchingGround && coyoteTimer > 0 && InputManager.instance.Jump.Queued)
            return PlayerStateMachine.EPlayerState.Jump;

        return StateKey;
    }
    
    
}
