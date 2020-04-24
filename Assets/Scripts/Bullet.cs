using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject shooter;
    private float damage = 0;
    private float speed = 10;
    private float ttl = 10;
    private LayerMask whatCanShoot;


    public void SetUp(GameObject shooter, float damage, float speed, float ttl, LayerMask layerMask)
    {
        this.shooter = shooter;
        this.damage = damage;
        this.speed = speed;
        this.ttl = ttl;
        this.whatCanShoot = layerMask;
    }

    void Update()
    {
        Invoke("SelfDestroy",ttl);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {        
        var colider = collision.collider.gameObject;

        if (GameObject.ReferenceEquals(shooter, colider))
            return;
       
         if (!CanShoot(colider))
            return;

        var damageable = colider.GetComponent<IDamageable>();
        if (damageable != null)
        {
              int o = 0;
        }
        damageable?.TakeDamage(damage);

        SelfDestroy();
    }

    public bool CanShoot(GameObject gameObject)
    {
        int layerNumber = gameObject.layer;
        return (whatCanShoot.value & 1 << layerNumber) == 1 << layerNumber;
    }
}