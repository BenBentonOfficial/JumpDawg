using UnityEngine;

public class Trap : SoundSyncListener
{
    protected Animator _animator;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Activate()
    {
        _animator.SetBool("Run", true);
    }

    protected virtual void DeActivate()
    {
        _animator.SetBool("Run", false);
    }

    protected override void Bump()
    {
    }
}
