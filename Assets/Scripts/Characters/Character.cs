using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[Serializable]
public class Character : MonoBehaviour, IDamageable, IMoveable
{
    [NonSerialized]
    public CharacterController characterController;

    public float speed;

    public float maxHp;


    private float hp;
    public float GetHp => hp;

    protected Action Die;

    public delegate void OnDie(GameObject diedGameObject);
    public OnDie onDie;

    public delegate void OnDamaged();
    public OnDamaged onDamaged;

    public void Initialization()
    {
        characterController = GetComponent<CharacterController>();
        hp = maxHp;
        Die = Die_;
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
            onDie?.Invoke(this.gameObject);
            Die();
        }

        onDamaged?.Invoke();
    }

    public void Die_()
    {
        SelfDestroy();
    }

    private void SelfDestroy()
    {

        Destroy(gameObject);
    }
}
