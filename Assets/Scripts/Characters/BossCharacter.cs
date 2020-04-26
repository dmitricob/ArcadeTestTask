using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : Character
{
    public AutoMoverToWithTime autoMover;

    private new void Initialization()
    {
        base.Initialization();
        autoMover = GetComponent<MoverTo>() as AutoMoverToWithTime;
        if (!autoMover)
            Debug.LogError("wrong automover");
    }

    private void Start()
    {
        this.Initialization();
    }

    public void MoveTo(Vector3 targetPosition)
    {
        autoMover.MoveTo(targetPosition);
    }




}
