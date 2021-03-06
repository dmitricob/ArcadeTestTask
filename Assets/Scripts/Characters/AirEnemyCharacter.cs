﻿using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyCharacter : Character
{
    public Shooter chracterShooter;
    public MoverTo characterMover;

    public new void Initialization()
    {
        base.Initialization();
        chracterShooter = GetComponent<Shooter>();
        characterMover = GetComponent<MoverTo>();

        Debug.Log($"{gameObject} mover is {characterMover} ");
    }

    private void Start()
    {
        this.Initialization();
    }

    public void Shoot()
    {
        chracterShooter.Shoot();
    }

    public void MoveTo(Vector3 targetPosition)
    {
        characterMover.MoveTo(targetPosition);
    }
}
