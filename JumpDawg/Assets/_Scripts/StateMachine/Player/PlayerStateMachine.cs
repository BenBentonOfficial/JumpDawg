using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine.EPlayerState>
{
    public enum EPlayerState
    {
        Idle, 
        Move,
    }

    public void Initialize(Player player, Rigidbody2D rb, Animator animator)
    {
        States.Add(EPlayerState.Idle, new Pla);
    }
}
