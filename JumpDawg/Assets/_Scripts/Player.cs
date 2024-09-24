using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D _rb;

    protected Animator _animator;

    protected int facingDir = 1;

    [SerializeField] protected float jumpForce;

    [SerializeField] protected float groundCheckDistance;

    [SerializeField] protected LayerMask groundLayer;
    
    public bool touchingGround => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        groundLayer = LayerMask.GetMask("Ground");

    }
    
}
