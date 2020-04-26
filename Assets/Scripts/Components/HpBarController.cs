using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetMaxHp(float maxHp)
    {
        slider.maxValue = maxHp;
        slider.value = maxHp;
    }

    public void SetHp(float hp)
    {
        slider.value = hp;
    }
}
