using System;
using UnityEngine;

public enum CollectibleType
{
    Apple,
    Banana,
    Cherry,
    Pineapple,
    Strawberry,
    Kiwi
}

public class Collectible : MonoBehaviour
{
    private Animator animator;

    private Collider2D coll;
    
    [SerializeField] private CollectibleType collectibleType;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        
        animator.SetLayerWeight((int)collectibleType, 1);
    }

    // called at end of collect animation via anim event
    private void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        coll.enabled = false;
        animator.SetTrigger("Collect");
        
        // add to collection
    }
}
