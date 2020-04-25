using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyCharacter : Character
{
    public Shooter chracterShooter;
    public AutoMover characterMover;

    public void Initialization()
    {
        base.Initialization();
        chracterShooter = GetComponent<Shooter>();
        characterMover = GetComponent<AutoMover>();
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
