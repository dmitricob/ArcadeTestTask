using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Character))]
public class BossController : MonoBehaviour
{
    public BossCharacter bossCharacter;

    public GameObject target;

    private RandomGenerator randomGenerator;

    private State newBossState;
    private State previousBossState;


    public float timeToMove = 2;
    public float timeToWait = 1;
    public float timeBetweenShoot = 0.2f;

    public int shootVolleyCount = 3;

    public float shootAngle = 30;

    public float speedBoost = 2;

    public float maxMove = 5;

    private float stateTime;

    void Start()
    {
        bossCharacter = GetComponent<BossCharacter>();
        
        if (!bossCharacter)
            Debug.LogError(gameObject + ": No character");

        bossCharacter.autoMover.OnArrive = OnMoveEnd;


        randomGenerator = new RandomGenerator(
            new Vector2(-13,-13), 
            new Vector2(13,13), 
            maxMove * 0.2f, 
            maxMove);


        target = FindObjectOfType<HeroCharacter>().gameObject;

        if (!target)
            Debug.LogError(gameObject+ ": No target");

        Wait();
    }

    private void VolleyOfShoots()
    {
        StartCoroutine(
            ShootInVolley(MoveToRandomPosition));
    }
    private IEnumerator ShootInVolley(Action onShootEnd, int currentShootNumber = 0)
    {
        if (currentShootNumber >= shootVolleyCount)
        {
            onShootEnd();
            yield break;
        }

        transform.LookAt(target.transform);

        bossCharacter.Shoot();
        yield return new WaitForSeconds(timeBetweenShoot);
        StartCoroutine(this.ShootInVolley(onShootEnd, currentShootNumber + 1));
        
    }
    private void MoveToRandomPosition()
    {
        bossCharacter.MoveTo(randomGenerator.GetRandomPosition(transform.position));
    }


    private void SpreadShoot()
    {
        transform.LookAt(target.transform.position);
        bossCharacter.ShootSpread(shootAngle);

        OnSpreadShootEnd();
    }
    private void OnSpreadShootEnd()
    {
        SetState(State.Idle);
        OnEndAction();
    }


    private void Move()
    {
        BoostSpeedSwap(speedBoost);
        bossCharacter.MoveTo(target.transform.position);
    }
    private void OnMoveEnd()
    {
        if (isSpeedBoosted)
            BoostSpeedSwap(speedBoost);

        SetState(State.Idle);
        OnEndAction();
    }

    private void Wait()
    {
        Invoke("OnWaitEnd", timeToWait);
    }
    private void OnWaitEnd()
    {
        //SetState(State.FireMode2);
        SetState(GetRandomState());
        OnEndAction();
    }

    private void OnEndAction()
    {
        switch (newBossState)
        {
            case State.Move:
                Move();
                break;

            case State.FireMode1:
                VolleyOfShoots();
                break;
            case State.FireMode2:
                SpreadShoot();
                break;

            case State.Idle:
                Wait(); 
                break;
        }
    }


    private void BoostSpeedSwap(float value)
    {
        isSpeedBoosted = !isSpeedBoosted;

        if (isSpeedBoosted)
            bossCharacter.speed *= value;
        else
            bossCharacter.speed /= value;

    }

    private int bossStateCount = 4;
    private bool isSpeedBoosted;

    enum State
    {
        Idle,
        Move,
        FireMode1,
        FireMode2
    }
    private State GetRandomState()
    {
        return (State)UnityEngine.Random.Range(1, bossStateCount); ;
    }

    private void SetState(State state)
    {
        previousBossState = newBossState;
        newBossState = state;
    }
}
