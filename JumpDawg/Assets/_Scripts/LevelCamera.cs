using Unity.Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    private CinemachineCamera cam;
    public LevelCameraTargetTrigger startingPos;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        if(startingPos != null)
            SwitchTarget(startingPos);
    }

    private void SwitchTarget(LevelCameraTargetTrigger trigger)
    {
        cam.Follow = trigger.transform;
        cam.Lens.OrthographicSize = trigger.lensSize;
    }

    private void Initialize()
    {
        cam = GetComponent<CinemachineCamera>();
        
        var levelTriggers = FindObjectsByType<LevelCameraTargetTrigger>(FindObjectsSortMode.None);

        foreach (var levelTrigger in levelTriggers)
        {
            levelTrigger.SwitchTarget += SwitchTarget;
        }
    }
}
