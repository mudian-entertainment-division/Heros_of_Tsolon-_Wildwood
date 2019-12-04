using UnityEngine;
using UnityEngine.UI;

public class RadialHealth : MonoBehaviour
{
    public Image radialHealthIcon;
    public float curHealth, maxHealth;

    [Header("Damage Effects")]

    public Image damageImage;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1, 0, 0, 0.2f);
    bool damaged;

    void HealthChange()
    {
        //Allows the damaging affect to take place
        float amount = Mathf.Clamp01(curHealth / maxHealth);
        radialHealthIcon.fillAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        HealthChange();
        //When player is damaged remove 5 hitpoints
        if (Input.GetKeyDown(KeyCode.A))
        {
            damaged = true;
            curHealth -= 5;
        }
        //When player is damaged flash screen
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
