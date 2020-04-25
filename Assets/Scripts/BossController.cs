using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossCharacter bossCharacter;

    private State currentBossState;
    private State previousBossState;

    public float timeToMove = 2;

    public float timeBetweenShoot = 0.2f;

    public float shootAngle = 30;


    private float stateTime;

    void Start()
    {
        bossCharacter = GetComponent<BossCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void MoveTo(Vector3 targetPosition)
    {

        Vector3 currentPostion = transform.position;



        bossCharacter.Move(targetPosition);
    }

    private State GetRandomState()
    {
        return (State)Random.Range(0,bossStateCount - 1);
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
