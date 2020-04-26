using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMoveable))]
public class AutoMoverTo : MoverTo
{
    void Update()
    {
        TryToMove();
    }   
}
