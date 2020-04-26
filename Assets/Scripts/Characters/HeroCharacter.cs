using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : Character
{
    private Shooter characterShooter;
    private TargetTracker targetTracker;

    public TargetTracker GetTargetTracker => targetTracker;

    public new void Initialization()
    {
        base.Initialization();

        characterShooter = gameObject.GetComponent<Shooter>();
        targetTracker = gameObject.GetComponent<TargetTracker>();

        targetTracker.onTargetFind = characterShooter.StartShooting;
        targetTracker.onTargetLost = characterShooter.StopShooting;

        //speed = 10;
        //hp = 20;
    }
    

    void Start()
    {
        this.Initialization();
    }

    internal void StopAttackMode()
    {
        targetTracker.StopTrack();
    }

    internal void StartAttackMode()
    {
        targetTracker.StartTrack();
    }

    public void Shoot()
    {
        characterShooter.Shoot();
    }
}
