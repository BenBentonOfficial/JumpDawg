
using System;
using UnityEngine;

public class SoundSyncPulse : SoundSyncListener
{
    [Header("Pulse Settings")] 
    [SerializeField] private float _pulseSize = 1.15f;

    [SerializeField] private float _returnSpeed = 5f;
    private Vector3 _startSize;

    protected override void Start()
    {
        base.Start();
        _startSize = transform.localScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _returnSpeed);
    }

    protected override void Bump()
    {
        transform.localScale = _startSize * _pulseSize;
    }
}
