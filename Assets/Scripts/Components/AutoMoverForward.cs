using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMoveable))]
public class AutoMoverForward : MonoBehaviour
{
    public GameObject target;

    private IMoveable moveable;

    private Vector3 direction;

    private bool isMoveAllowed;


    void Start()
    {
        moveable = GetComponent<IMoveable>();

        target = FindObjectOfType<HeroCharacter>().gameObject;
        if (!target)
            Debug.LogError("No target");
    }
    void Update()
    {
        if (!isMoveAllowed)
            return;

        direction = DirectionToTarget();
        direction *= Time.deltaTime;

        moveable.Move(direction);
    }

    public void StartMove() => isMoveAllowed = true;
    public void StopMove() => isMoveAllowed = false;

    private Vector3 DirectionToTarget()
    {
        if (!target)
            return default(Vector3);

        direction = target.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        return direction;
    }
}
