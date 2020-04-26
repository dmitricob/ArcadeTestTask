using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : Character, IShootable
{
    public AutoMoverToWithTime autoMover;

    private Shooter shooter;

    private new void Initialization()
    {
        base.Initialization();
        autoMover = GetComponent<MoverTo>() as AutoMoverToWithTime;
        if (!autoMover)
            Debug.LogError("wrong automover");

        //shootable = GetComponent<IShootable>();
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        this.Initialization();
    }

    public void MoveTo(Vector3 targetPosition)
    {
        autoMover.MoveTo(targetPosition);
    }

    public void Shoot()
    {
        shooter.Shoot();
    }

    public void ShootSpread(float shootAngle)
    {
        shooter.Shoot();
        shooter.Shoot(new Vector3(0, 1, 0), shootAngle);
        shooter.Shoot(new Vector3(0, 1, 0), -1*shootAngle);
    }
}
