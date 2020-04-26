using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    public GroundEnemyCharacter enemyCharacter;

    public GameObject target;

    private Vector3 direction;

    private MoverTo autoMover;
    
    void Start()
    {
        target = FindObjectOfType<HeroCharacter>().gameObject;
        autoMover = GetComponent<MoverTo>();
    }

    private void Update()
    {       
        autoMover.MoveTo(target.transform.position);
    }
}
