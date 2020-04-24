using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyController : MonoBehaviour
{
    public AirEnemyCharacter enemyCharacter;

    public GameObject target;

    public float maxDistansPerMove;

    private float time;
    private float dist;

    private State currentState;
    private State previousState;


    public Vector3 targetPosition;
    private Vector3 direction;

    public float curentMoveTime;
    public float timeToMove;

    public float speed = 10; 
    public float positionBias = 0.001f;

    private bool wait;
    void Start()
    {
        enemyCharacter = GetComponent<AirEnemyCharacter>();

        target = FindObjectOfType<HeroCharacter>().gameObject;

        currentState = State.Idle;
        previousState = State.Idle;

        SetRandomPosition();
    }


    void Update()
    {      
        if(Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            curentMoveTime = 0;
            if (!wait)
            {
                wait = true;
                Invoke("Shoot",0.5f);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, curentMoveTime / timeToMove);
            curentMoveTime += Time.deltaTime;
        }

    }

    private void SetRandomPosition()
    {
        wait = false;
        targetPosition = GetRandomPosition();

        float distance = Vector3.Distance(transform.position, targetPosition);
        timeToMove = distance / speed;
    }

    private Vector3 GetRandomPosition()
    {
        var offset = new Vector3(
            GetcorrespondingRandomOffset(),
            0,
            GetcorrespondingRandomOffset());
        var position = transform.position + offset;

        float xs = GetSight(-13, 13, position.x);
        float zs = GetSight(-13, 13, position.z);

        position += new Vector3(xs * offset.x * 2, 0, zs * offset.z * 2);

        return position;
    }

    public float GetSight(float min, float max, float value)
    {
        //if (value < min)
        //    return 1;
        //if (value > max)
        //    return -1;
        //return 0;

        if (value < min || value > max)
            return -1;
        return 0;
    }

    private float GetcorrespondingRandomOffset()
    {
        float minOffset = positionBias * 2;
        float offset = Random.Range(-maxDistansPerMove + minOffset, maxDistansPerMove - minOffset);
        offset += offset / Mathf.Abs(offset) * minOffset;
        return offset;
    }

    private void Shoot()
    {
        transform.LookAt(target.transform);
        enemyCharacter.Shoot();
        Invoke("SetRandomPosition", 0.5f);
    }

    private void SetState(State state)
    {
        previousState = currentState;
        currentState = state;
    }
    enum State
    {
        Idle,
        Move,
        Shoot
    }
}
