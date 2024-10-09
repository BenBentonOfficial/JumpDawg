using UnityEngine;

public class PlayerPlatformFallState : PlayerState
{
    public PlayerPlatformFallState(PlayerStateMachine.EPlayerState key, Player entity, Rigidbody2D rb, Animator anim) : base(key, entity, rb, anim)
    {
    }

    private PassthroughPlatform platform;

    public override void EnterState()
    {
        base.EnterState();
        platform = player.GetPlatform();
        platform.TogglePassthrough(player.Collider);
        stateTimer = 0.2f;
    }

    public override void ExitState()
    {
        base.ExitState();
        platform.TogglePassthrough(player.Collider);
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        player.SetVelocityX((player.MoveSpeed * 0.8f) * InputManager.MovementInput().x);

        player.SetGravity(RB.gravityScale += Time.deltaTime * 3f);
        
        player.CheckFlip();
        
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (stateTimer <= 0)
            return PlayerStateMachine.EPlayerState.Fall;

        if (player.touchingGround && stateTimer <= 0)
            return PlayerStateMachine.EPlayerState.Idle;
        
        return StateKey;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
