using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyController : MonoBehaviour
{
    public AirEnemyCharacter enemyCharacter;

    public GameObject target;

    public float maxDistansPerMove;
    public Vector2 leftBotBounding;
    public Vector2 rightTopBounding;
    public float timeToWait;

    private RandomGenerator randomGenerator;

    private State currentState;
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

        currentState = State.Idle;
        previousState = State.Idle;

        MoveToRandoimPosition();
    }


    private bool IsPreviousStateIs(State state) => this.previousState == state;
    private void SetState(State state)
    {
        previousState = currentState;
        currentState = state;
    }
    private enum State
    {
        Idle,
        Move,
        Shoot
    }

    private IEnumerator Shoot()
    {
        SetState(State.Shoot);

        yield return new WaitForSeconds(timeToWait * 0.5f);

        if(target)
            transform.LookAt(target.transform);
        
        enemyCharacter.Shoot();

        Invoke("OnShootEnd", timeToWait * 0.5f);
    }
    private void OnShootEnd()
    {
        SetState(State.Idle);
        OnActionEnd();
    }

    private void MoveToRandoimPosition()
    {
        SetState(State.Move);
        enemyCharacter.MoveTo(randomGenerator.GetRandomPosition(transform.position));
    }
    private void OnMoveEnd()
    {
        SetState(State.Idle);
        OnActionEnd();
    }

    private void OnActionEnd()
    {
        switch (previousState)
        {
            case State.Move:
                StartCoroutine(Shoot());
                break;

            case State.Shoot:
                MoveToRandoimPosition();
                break;
        }
    }

}
