using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AirEnemyController : MonoBehaviour
{
    public AirEnemyCharacter enemyCharacter;

    public GameObject target;

    public float maxDistansPerMove;
    public Vector2 leftBotBounding;
    public Vector2 rightTopBounding;
    public float timeToWait;

    private RandomGenerator randomGenerator;

    private State newState;
    private State previousState;

    public float speed = 10; 

    void Start()
    {
        target = FindObjectOfType<HeroCharacter>().gameObject;
        if (!target)
            Debug.LogError("No hero active");

        enemyCharacter = GetComponent<Character>() as AirEnemyCharacter;
        enemyCharacter.characterMover.OnArrive = OnMoveEnd;

        randomGenerator = new RandomGenerator(leftBotBounding,rightTopBounding,maxDistansPerMove * 0.2f,maxDistansPerMove);

        //newState = State.Idle;
        //previousState = State.Idle;

        Wait();
    }


    private bool IsPreviousStateIs(State state) => this.previousState == state;
    private void SetState(State state)
    {
        previousState = newState;
        newState = state;
    }
    private enum State
    {
        Idle,
        Move,
        Shoot
    }


    private void Shoot()
    {
        if(target)
            transform.LookAt(target.transform);
        
        enemyCharacter.Shoot();

        Invoke("OnShootEnd", timeToWait);
    }
    private void OnShootEnd()
    {
        SetState(State.Idle);
        OnActionEnd();
    }

    private void MoveToRandoimPosition()
    {
        enemyCharacter.MoveTo(randomGenerator.GetRandomPosition(transform.position));
    }
    private void OnMoveEnd()
    {
        SetState(State.Idle);
        OnActionEnd();
    }

    private void Wait()
    {
        Invoke("OnWaitEnd", timeToWait);
    }
    private void OnWaitEnd()
    {
        switch (previousState)
        {
            case State.Move:
                SetState(State.Shoot);
                break;

            case State.Shoot:
                SetState(State.Move);
                break;

            default:
                SetState(State.Move);
                break;
        }

        OnActionEnd();
    }

    private void OnActionEnd()
    {
        switch (newState)
        {
            case State.Move:
                MoveToRandoimPosition();
                break;

            case State.Shoot:
                Shoot();
                break;

            case State.Idle:
                Wait();
                break;
        }
    }

}
