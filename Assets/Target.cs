using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public void TakeDamage(float damage)
    {
        GetComponent<Renderer>().material.color = Color.red;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-0.1f,0.1f),0, Random.Range(-0.1f, 0.1f)));
    }
}
