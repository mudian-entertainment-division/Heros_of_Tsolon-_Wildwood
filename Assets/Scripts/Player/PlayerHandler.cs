using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerStats
    {
        public string name;
        public int value;
    }

    [Header("Value Variables")]

    public float curHealth;
    public float curMana, maxHealth, maxMana;

    [Header("Value Icons")]

    public Image radialHealthIcon;
    public Image radialManaIcon;

    [Header("Damage Effects")]

    public Image damageImage;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1, 0, 0, 0.2f);
    bool damaged;

    void Update()
    {
        HealthChange();
        ManaChange();

        void HealthChange()
        {
            float amount = Mathf.Clamp01(curHealth / maxHealth);
            radialHealthIcon.fillAmount = amount;
        }
        void ManaChange()
        {
            float amount = Mathf.Clamp01(curMana / maxMana);
            radialManaIcon.fillAmount = amount;
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
    }
}
