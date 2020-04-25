using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IShootable
{
    public GameObject projectilePrefab;
    public float fireRate;
    public float damage;
    public float bulletTtl;
    public float bulletSpeed;
    public LayerMask whatCanShoot;

    public Vector3 offset;

    private bool isShooting;
    public bool IsShooting { get; }

    private float time;

    private void Start()
    {
        if (projectilePrefab.GetComponent<Bullet>() == null)
            Debug.LogError("Bullet pref doest contain bullet script");
    }

    public void Shoot()
    {
        var newBullet = Instantiate(projectilePrefab,transform.position + offset,transform.rotation);
        newBullet.GetComponent<Bullet>().SetUp(gameObject,damage,bulletSpeed,bulletTtl, whatCanShoot);

        Debug.DrawRay(transform.position + offset, transform.forward * 50,Color.red);

    }

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;
            time = Time.time + 1 / fireRate;
        }
    }
    public void StopShooting() => isShooting = false;


    private void Update()
    {
        if (isShooting
            && Time.time > time)
        {
            time = Time.time + 1 / fireRate;

            Shoot();
        }
    }


}
