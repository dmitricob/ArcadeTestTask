using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HeroCharacter heroCharacter;
    private Vector3 motion;
    private float moveBias = 0.001f;

    private void Start()
    {
        heroCharacter = GetComponent<HeroCharacter>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if moving // ???

        motion = new Vector3(SimpleInput.GetAxis("Horizontal"), 0, SimpleInput.GetAxis("Vertical"));
        //motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (Mathf.Abs(motion.x) < moveBias
         && Mathf.Abs(motion.z) < moveBias)
        {
            if(!heroCharacter.GetTargetTracker.IsTracking)
                heroCharacter.StartAttackMode();
        }
        else
        {
            //if(heroCharacter.targetTracker.IsTracking)
                heroCharacter.StopAttackMode();
            motion *= Time.deltaTime;
            heroCharacter.Move(motion);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            heroCharacter.Shoot();
        }

    }


}
