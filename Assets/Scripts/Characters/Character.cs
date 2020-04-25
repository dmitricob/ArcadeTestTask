using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable, IMoveable

{
    public CharacterController characterController;

    [SerializeField]
    public float speed;

    [SerializeField]
    public float hp;


    public void Initialization()
    {
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// move on specified direction (motion) with seted speed (speed)
    /// </summary>
    /// <param name="motion">normalized for update move direction</param>
    public void Move(Vector3 diretion)
    {
        diretion *= speed;
        characterController.Move(diretion);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject + " take damage " + damage);

        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            OnDie();
        }
    }

    public void OnDie()
    {
        Destroy(gameObject);
    }
}
