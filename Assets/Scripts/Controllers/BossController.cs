using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Character))]
public class BossController : MonoBehaviour
{
    public BossCharacter bossCharacter;

    public GameObject target;


    private State currentBossState;
    private State previousBossState;

    public float timeToMove = 2;
    public float timeToWait = 1;
    public float timeBetweenShoot = 0.2f;

    public float shootAngle = 30;



    private float stateTime;

    void Start()
    {
        bossCharacter = GetComponent<BossCharacter>();
        
        if (!bossCharacter)
            Debug.LogError(gameObject + ": No character");

        bossCharacter.autoMover.OnArrive = OnEndMove;


        target = FindObjectOfType<HeroCharacter>().gameObject;

        if (!target)
            Debug.LogError(gameObject+ ": No target");

        StartMove();
    }


    private void StartMove()
    {
        bossCharacter.MoveTo(target.transform.position);
    }
    private void OnEndMove()
    {
        SetState(State.Idle);
        OnEndAction();
    }

    private void OnWait()
    {
        SetState(State.Move);
        //SetState(GetRandomState());
        OnEndAction();
    }

    private void OnEndAction()
    {
        switch (currentBossState)
        {
            case State.Move:
                StartMove();
                break;
            case State.Idle:
                Invoke("OnWait", timeToWait);
                break;
        }
    }

    private State GetRandomState()
    {
        return (State)Random.Range(1,bossStateCount - 1);
    }

    private void SetState(State state)
    {
        previousBossState = currentBossState;
        currentBossState = state;
    }


    private int bossStateCount = 4;
    enum State
    {
        Idle,
        Move,
        FireMode1,
        FireMode2
    }
}
