using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AutoMoverToWithTime : MoverTo
{
    public float timeToMove;

    private float time;

    private void Update()
    {
        if (IsTimeOver && IsMoveAllowed)
        {
            time = 0;
            EndMove();
        }
        else
        {
            time += Time.deltaTime;
            TryToMove();
        }
    }

    private bool IsTimeOver => time > timeToMove;
}
