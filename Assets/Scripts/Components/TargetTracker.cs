using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    public float findRadius;
    public LayerMask whoToTrack;

    private GameObject target;

    private bool isTracking;
    public bool IsTracking { get; }

    public Action onTargetTracking;
    public Action onTargetFind;
    public Action onTargetLost;

    private NearestFinder nearestFinder;

    private void Start()
    {
        nearestFinder = new NearestFinder(findRadius, whoToTrack);
    }


    private void Update()
    {
        if (isTracking && NoTarget())
        {
            FindNewTarget();
        }
        if (isTracking)
        {
            LookAtTarget();
            if (onTargetTracking != null)
                onTargetTracking();
        }
    }

    private void ResetLook()
    {
        transform.rotation = Quaternion.identity;
    }

    private void LookAtTarget()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
    }

    public void StartTrack()
    {
        isTracking = true;
        if (GameObject.ReferenceEquals(target, null))
        {
            FindNewTarget();
        }

        if (isTracking )
            onTargetFind?.Invoke();
    }

    public void StopTrack()
    {
        isTracking = false;
        ResetLook();
        ClearTarget();
        onTargetLost();
    }

    private void FindNewTarget()
    {
        target = nearestFinder.FindNearest(transform);

        if (NoTarget())
            StopTrack();
    }

    private bool NoTarget() => target == null;


    public void ClearTarget()
    {
        target = null;
    }
}
