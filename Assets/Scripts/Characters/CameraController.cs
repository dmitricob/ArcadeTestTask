using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;
    private Action OnUpdate;
    // Start is called before the first frame update
    void Start()
    {
        OnUpdate = Init;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        OnUpdate?.Invoke();            
    }

    private void Init()
    {
        target = FindObjectOfType<HeroCharacter>()?.gameObject;
        if (target != null)
        {
            offset = transform.position - target.transform.position;
            OnUpdate -= Init;
            OnUpdate += Track;
        }
    }
    private void Track()
    {
        transform.position = target.transform.position + offset;
    }
}
