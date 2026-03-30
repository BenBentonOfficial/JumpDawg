using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IMoving
{
    [SerializeField] private List<Transform> positions;
    private int targetIndex = 0;
    [SerializeField] private float moveSpeed = 5;
    
    public Vector2 Direction() => positions[targetIndex].position - transform.position;
    
    //lerps (ease in / out) position

    private void FixedUpdate()
    {
        var target = positions[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            targetIndex++;
            if (targetIndex >= positions.Count)
                targetIndex = 0;
        }
    }
    
        // Make the player a child of the platform when they collide
        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            collision.collider.transform.SetParent(transform);
            
        }
    
        // Unparent the player when they leave the platform
        private void OnCollisionExit2D(Collision2D collision)
        {
            collision.collider.transform.SetParent(null);
        }

}
