using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestFinder
{
    private float findRadius = 10;
    private LayerMask whoToFind;

    public NearestFinder(float findRadius, LayerMask whoToFind)
    {
        this.findRadius = findRadius;
        this.whoToFind = whoToFind;
    }

    public GameObject FindNearest(Transform transform)
    {
        var targets = Physics.OverlapSphere(transform.position, findRadius, whoToFind);

        if (targets.Length == 0)
            return default(GameObject);

        Array.Sort(targets, new DistanceComparer(transform));
        return targets[0].gameObject;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, findRadius);
    //}
}

class DistanceComparer : IComparer<Collider>
{
    private Transform origin;
    public DistanceComparer(Transform origin)
    {
        this.origin = origin;
    }
    public int Compare(Collider x, Collider y)
    {
        float distx = Vector3.Distance(x.gameObject.transform.position, origin.position);
        float disty = Vector3.Distance(y.gameObject.transform.position, origin.position);
        return distx.CompareTo(disty);
    }
}
