using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine.EPlayerState>
{
    public enum EPlayerState
    {
        Idle, 
        Move,
        Jump
    }

    public void Initialize(Player player, Rigidbody2D rb, Animator animator)
    {
        States.Add(EPlayerState.Idle, new PlayerIdleState(EPlayerState.Idle, player, rb, animator));
        States.Add(EPlayerState.Move, new PlayerMoveState(EPlayerState.Move, player, rb, animator));
        States.Add(EPlayerState.Jump, new PlayerJumpState(EPlayerState.Jump, player, rb, animator));

        CurrentState = States[EPlayerState.Idle];
    }
}
