using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    public GroundEnemyCharacter enemyCharacter;

    public GameObject target;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
            target = FindObjectOfType<HeroCharacter>().gameObject;
        enemyCharacter = GetComponent<GroundEnemyCharacter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = DirectionToTarget();
        direction *= Time.deltaTime;

        enemyCharacter.Move(direction);
    }

    private Vector3 DirectionToTarget()
    {
        direction = target.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        return direction;
    }
}
