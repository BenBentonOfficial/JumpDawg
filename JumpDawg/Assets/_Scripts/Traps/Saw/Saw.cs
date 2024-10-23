using System;
using System.Collections;
using UnityEngine;

public class Saw : Trap
{
    [SerializeField] private Vector2[] pivotPoints;
    private int targetIndex = 0;
    [SerializeField] private float speed;


    [SerializeField] Transform saw;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Bump()
    {
        base.Bump();
        GetNextPoint();
        StartCoroutine(Travel(pivotPoints[targetIndex] + (Vector2)transform.position,intervalLength));
    }

    private void GetNextPoint()
    {
        if (targetIndex >= pivotPoints.Length - 1)
        {
            targetIndex = 0;
            return;
        }
        
        targetIndex++;
    }

    IEnumerator Travel(Vector2 targetPos, float duration)
    {
        Activate();
        float time = 0;
        Vector2 startPos = saw.position;
        var distance = (targetPos - startPos);

        while (time < duration)
        {
            saw.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime * distance.magnitude * speed;
            yield return new WaitForEndOfFrame();
        }
        
        DeActivate();

        saw.position = targetPos;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (pivotPoints == null)
            return;
        
        foreach (var pivot in pivotPoints)
        {
            Gizmos.DrawWireSphere(transform.position + (Vector3)pivot, 0.25f);
        }
    }
}
