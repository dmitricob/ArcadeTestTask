using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IDamageable, IMoveable

{
    public CharacterController characterController;

    [SerializeField]
    public float speed;

    [SerializeField]    
    public float maxHp;

    private float hp;
    public float GetHp => hp;

    public Action OnDie;

    public delegate void OnDamaged();
    public OnDamaged onDamaged;

    public void Initialization()
    {
        characterController = GetComponent<CharacterController>();
        hp = maxHp;

        OnDie = SelfDestroy;
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
        Debug.Log(gameObject + $" take {damage} damage");
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            OnDie();
        }

        onDamaged.Invoke();
    }

    public void Die()
    {
        OnDie();
    }

    private void SelfDestroy()
    {

        Destroy(gameObject);
    }
}
