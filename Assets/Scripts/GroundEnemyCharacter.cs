using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyCharacter : Character
{
    public void Initialization()
    {
        base.Initialization();

        //hp = 5;
        //speed = 5;
    }
    private void Start()
    {
        this.Initialization();
    }


}
