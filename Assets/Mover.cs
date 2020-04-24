using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10;
    public Vector3 targetPosition;
    public Action OnArrive; 
    //private float curentMoveTime;
    //private float timeToMove;
    private float positiongBias = 0.0001f;
    private bool isMoveAllowed;

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
            //float traveled = curentMoveTime / timeToMove;
            //transform.position = Vector3.Lerp(transform.position, targetPosition, curentMoveTime / timeToMove);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            //curentMoveTime += Time.deltaTime;
        }
    }

    public void MoveTo(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        isMoveAllowed = true;
    }

    public void StopMove()
    {
        isMoveAllowed = false;
    }

    private bool IsCame => targetPosition != null 
                            && Vector3.Distance(transform.position, targetPosition) < positiongBias ;
    //private bool IsCame => curentMoveTime > timeToMove;
}
