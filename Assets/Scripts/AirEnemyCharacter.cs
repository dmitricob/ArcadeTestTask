using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyCharacter : Character
{
    public Shooter chracterShooter;

    public void Initialization()
    {
        base.Initialization();
        chracterShooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        this.Initialization();
    }

    public void Shoot()
    {
        chracterShooter.Shoot();
    }
}
