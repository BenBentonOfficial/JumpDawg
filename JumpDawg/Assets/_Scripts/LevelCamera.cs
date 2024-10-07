using System;
using Unity.Cinemachine;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    private CinemachineCamera cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
    }

    private void Start()
    {
        var levelTriggers = FindObjectsByType<LevelCameraTargetTrigger>(FindObjectsSortMode.None);

        foreach (var levelTrigger in levelTriggers)
        {
            levelTrigger.SwitchTarget += SwitchTarget;
        }
    }

    private void SwitchTarget(Transform newTarget)
    {
        cam.Follow = newTarget;
    }
}
