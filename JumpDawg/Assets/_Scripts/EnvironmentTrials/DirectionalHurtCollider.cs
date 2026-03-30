using System;
using UnityEngine;

public class DirectionalHurtCollider : MonoBehaviour
{
    public IMoving moving;

    private void OnEnable()
    {
        moving = GetComponent<IMoving>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
}
