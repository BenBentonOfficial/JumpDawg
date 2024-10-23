using System;
using UnityEngine;

public enum SyncInterval
{
    whole,
    half,
    quarter,
    eighth
}
public class SoundSyncManager : MonoBehaviour
{
    public static SoundSyncManager instance;

    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Interval[] _intervals;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Update()
    {
        foreach (var interval in _intervals)
        {
            float sampledTime = _audioSource.timeSamples / (_audioSource.clip.frequency *
                                 interval.GetIntervalLength(_bpm));
            interval.CheckForNewInterval(sampledTime);
        }
    }

    public Interval GetInterval(SyncInterval interval) => _intervals[(int)interval];
    public float GetIntervalLength(SyncInterval interval) => _intervals[(int)interval].GetIntervalLength(_bpm);
}

[Serializable]
public class Interval
{
    [SerializeField] private float _steps;

    private int _lastInterval;

    public Action _trigger;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps);
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger?.Invoke();
        }
    }
}
