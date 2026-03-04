using UnityEngine;

public class Player : Entity
{
    public PlayerStateMachine StateMachine { get; private set; }
    

    protected override void Awake()
    {
        base.Awake();
        StateMachine = GetComponent<PlayerStateMachine>();
        StateMachine.Initialize(this, _rb, _animator);

    }

    public bool OnPlatform()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            return hit.collider.CompareTag("Platform");
        } 
        
        return false;
    } 
    
    public PassthroughPlatform GetPlatform() => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer).collider.gameObject.GetComponent<PassthroughPlatform>();

}
