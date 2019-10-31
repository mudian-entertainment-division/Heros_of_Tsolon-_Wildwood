using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMana : MonoBehaviour
{
    public Image radialManaIcon;
    public float curMana, maxMana;

    bool ManaUsed;
    public float ManaPerSecond = 1f;

    private void Start()
    {
        InvokeRepeating("Timer", 1, 1f);
    }

    void ManaChange()
    {
        float amount = Mathf.Clamp01(curMana / maxMana);
        radialManaIcon.fillAmount = amount;
    }
    void Update()
    {
        ManaChange();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            curMana -= 1;
        }

        if (curMana > 10)
        {
            curMana = 10;
        }
    }
    private void Timer()
    {
        curMana += ManaPerSecond;
    }
}