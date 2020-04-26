using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamager : MonoBehaviour
{
    public float damage;    // per sec

    private float timeTodamage = 1; // sec
    private float time;
    private GameObject currentColider;

    private void Start()
    {
        if (!gameObject.GetComponent<Collider>())
            Debug.LogError(gameObject + " havent collider ");
    }
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && other.CompareTag("Player"))
        {
            currentColider = other.gameObject;
            damageable.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(time > timeTodamage)
        {
            time = 0;
            currentColider.GetComponent<IDamageable>().TakeDamage(damage);
        }
        time += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentColider = null;
            time = 0;
        }
    }

}
