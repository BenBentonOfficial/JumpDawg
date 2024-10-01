using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D _rb;

    protected Animator _animator;

    protected int facingDir = 1;

    [SerializeField] protected float jumpForce;

    [SerializeField] protected float groundCheckDistance;

    [SerializeField] protected LayerMask groundLayer;
    
    public bool touchingGround => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

    public Animator Animator => _animator;
    public float JumpForce => jumpForce;
    public int FacingDir => facingDir;
    
    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    public void ZeroVelocity() => _rb.linearVelocity = Vector2.zero;

    public void SetVelocity(Vector2 newVelocity) => _rb.linearVelocity = newVelocity;
    public void SetVelocityX(float newXVelocity) => _rb.linearVelocity = new Vector2(newXVelocity, _rb.linearVelocityY);
    public void SetVelocityY(float newYVelocity) => _rb.linearVelocity = new Vector2(_rb.linearVelocityX, newYVelocity);
    public Vector2 Velocity() => _rb.linearVelocity;

    public void SetGravity(float newGravity) => _rb.gravityScale = newGravity;

    public virtual void CheckFlip()
    {
        if (Velocity().x < 0 && facingDir == 1)
        {
            Flip(180f);
        }
        else if (Velocity().x > 0 && facingDir == -1)
        {
            Flip(0f);
        }
    }

    protected virtual void Flip(float newRot)
    {
        Vector3 newDir = new Vector3(transform.rotation.x, newRot, transform.rotation.z);
        transform.rotation = Quaternion.Euler(newDir);
        facingDir *= -1;
    }

    private void OnDrawGizmosSelected()
    {
        var groundCheckEndPoint = new Vector3(transform.position.x, transform.position.y - groundCheckDistance, 0f);
        Gizmos.DrawLine(transform.position, groundCheckEndPoint);
    }

}
