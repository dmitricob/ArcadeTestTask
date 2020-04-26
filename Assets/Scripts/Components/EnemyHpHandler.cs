using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpBarController))]
public class EnemyHpHandler : HpHandler
{
    public override void CharacterFinder()
    {
        character = GetComponent<Character>();
    }

    public override void HpBarFinder()
    {
        hpBarController = GetComponent<HpBarController>();
    }
}
