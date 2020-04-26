using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(CharacterController))]
public class TouchDamager : MonoBehaviour
{
    public float damage;    // per sec

    private float timeTodamage = 1; // sec
    private float time;
    private float hitTime;
    private GameObject currentColider;

    private void Start()
    {
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var damageable = hit.gameObject.GetComponent<IDamageable>();
        if (damageable != null && hit.gameObject.CompareTag("Player"))
        {
            if (Time.time - hitTime > timeTodamage )
            {
                currentColider = hit.gameObject;
                damageable.TakeDamage(damage);
                hitTime = Time.time;
            }
        }
    }

    // broken
    //private void OnTriggerEnter(Collider other)
    //{
    //    var damageable = other.GetComponent<IDamageable>();
    //    if (damageable != null && other.CompareTag("Player"))
    //    {
    //        currentColider = other.gameObject;
    //        damageable.TakeDamage(damage);
    //        Debug.Log(currentColider + " on enter colision with " + gameObject);
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if(time > timeTodamage)
    //    {
    //        time = 0;
    //        currentColider.GetComponent<IDamageable>().TakeDamage(damage);
    //    }
    //    time += Time.deltaTime;
        
    //    Debug.Log(currentColider + " on stay colision with " + gameObject);

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        currentColider = null;
    //        time = 0;
    //    }
    //}

}
