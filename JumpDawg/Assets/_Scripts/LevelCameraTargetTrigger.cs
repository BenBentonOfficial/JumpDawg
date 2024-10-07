using System;
using UnityEngine;

public class LevelCameraTargetTrigger : MonoBehaviour
{

    public Action<Transform> SwitchTarget;

    private void OnTriggerEnter2D(Collider2D col)
    {
        SwitchTarget?.Invoke(this.transform);
    }
}
