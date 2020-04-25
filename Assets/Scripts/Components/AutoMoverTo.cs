using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoverTo : MonoBehaviour
{
    public float speed = 10;
    private Vector3 targetPosition;
    public Action OnArrive;
    //public Action<Vector3> MoveAction;

    private float positiongBias = 0.0001f;
    private bool isMoveAllowed;

    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }

    void Update()
    {
        if (isMoveAllowed)
        {
            if (IsCame)
            {
                isMoveAllowed = false;
                OnArrive?.Invoke();
                this.targetPosition = default(Vector3);
                return;
            }
            //MoveAction(Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    public void MoveTo(Vector3 targetPosition, bool startMoveImmediately = true)
    {
        this.targetPosition = targetPosition;
        isMoveAllowed = startMoveImmediately;
    }
    public void StartMove()
    {
        isMoveAllowed = true;
    }
    public void StopMove()
    {
        isMoveAllowed = false;
    }

    private bool IsCame => targetPosition != null 
                            && Vector3.Distance(transform.position, targetPosition) < positiongBias ;
    

}
