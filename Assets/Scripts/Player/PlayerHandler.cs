
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]

    public float curHealth;
    public float curEnergy, maxHealth, maxEnergy;
    public float energyPerSecond = 1f;
    public float healthPerSecond = 1f;

    [Header("Value Variables")]

    public Image radialHealthIcon;
    public Image radialEnergyIcon;

    [Header("Damage Effect Variables")]

    public Image damageImage;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1, 1, 0, 0.2f);
    bool damaged;

    private void Start()
    {
        InvokeRepeating("Timer", 1, 1f);
    }
    void Update()
    {
        HealthChange();

        EnergyChange();

        void HealthChange()
        {
            float amount = Mathf.Clamp01(curHealth / maxHealth);
            radialHealthIcon.fillAmount = amount;

            if (curHealth > 245)
            {
                curHealth = 245;
            }
            if (curHealth > 245)
            {
                curHealth = 245;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            damaged = true;
            curHealth -= 5;
        }
        if (damaged)
        {
            damageImage.color = flashColor;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        void EnergyChange()
        {
            float amount = Mathf.Clamp01(curEnergy / maxEnergy);
            radialEnergyIcon.fillAmount = amount;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curEnergy -= 1;
        }

        if (curEnergy > 10)
        {
            curEnergy = 10;
        }

    }
    private void Timer()
    {
        curEnergy += energyPerSecond;
        curHealth += healthPerSecond;
    }
    
}

