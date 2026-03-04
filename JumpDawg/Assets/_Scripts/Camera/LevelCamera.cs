using Unity.Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    public static LevelCamera instance;
    private CinemachineCamera cam;
    public Transform startingPos;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        
        cam = GetComponent<CinemachineCamera>();
        
        SwitchRooms(startingPos);
    }

    public void SwitchRooms(Transform nextRoom)
    {
        cam.Follow = nextRoom;
    }

    
    
}
