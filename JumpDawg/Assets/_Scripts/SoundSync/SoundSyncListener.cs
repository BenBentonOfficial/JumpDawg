using UnityEngine;

public abstract class SoundSyncListener : MonoBehaviour
{
    [SerializeField] private SyncInterval _interval;
    protected float intervalLength;

    protected virtual void Start()
    {
        SoundSyncManager.instance.GetInterval(_interval)._trigger += Bump;
        intervalLength = SoundSyncManager.instance.GetIntervalLength(_interval);
    }

    private void OnDestroy()
    {
        SoundSyncManager.instance.GetInterval(_interval)._trigger -= Bump;
    }

    protected abstract void Bump();
}
