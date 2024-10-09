using System;
using UnityEngine;

public class LevelCameraTargetTrigger : MonoBehaviour
{

    public Action<LevelCameraTargetTrigger> SwitchTarget;
    public float lensSize;

    private void OnTriggerEnter2D(Collider2D col)
    {
        SwitchTarget?.Invoke(this);
    }
}
