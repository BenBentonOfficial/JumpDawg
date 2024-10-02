using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    private bool jumpEnd = false;

    private void EndJump() => jumpEnd = true;

    public override void EnterState()
    {
        base.EnterState();
        jumpEnd = false;
        InputManager.instance.Jump.cancel += EndJump;
        InputManager.instance.Jump.Consume();
        
        player.SetVelocityY(player.JumpForce);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
       
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (player.touchingGround)
            return PlayerStateMachine.EPlayerState.Idle;
        
        

        return StateKey;
    }

    public override void AnimationFinishTrigger()
    {
        throw new System.NotImplementedException();
    }
}
