using System.Collections.Generic;
using UnityEngine;


public enum TransitionDirection
{
    vertical,
    horizontal
}
public class RoomTransitionTrigger : MonoBehaviour
{
    [SerializeField] private List<Transform> rooms;
    [SerializeField] private float lensSize;
    
    [Space]
    [SerializeField] private TransitionDirection transitionDirection;

    private float offset = 1f;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("triggered");
        var playerPos = col.transform.position;

        if (transitionDirection == TransitionDirection.vertical)
        {
            VerticalTransition(playerPos.y);
        }
        else
        {
            HorizontalTransition(playerPos.x);
        }
    }

    private void VerticalTransition(float y)
    {
        if (y > transform.position.y)
        {
            LevelCamera.instance.SwitchRooms(rooms[1]);
            transform.position += new Vector3(0, offset, 0);
        }
        else
        {
            LevelCamera.instance.SwitchRooms(rooms[0]);
            transform.position -= new Vector3(0, offset, 0);
        }
    }
    
    private void HorizontalTransition(float x)
    {
        if (x > transform.position.x)
        {
            LevelCamera.instance.SwitchRooms(rooms[0]);
            transform.position += new Vector3(offset, 0, 0);
        }
        else
        {
            LevelCamera.instance.SwitchRooms(rooms[1]);
            transform.position -= new Vector3(offset,0, 0);
        }
    }
}
