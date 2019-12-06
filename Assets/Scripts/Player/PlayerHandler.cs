
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Xml.Serialization;
using System.Xml;

[System.Serializable]
public class PlayerData
{
    [XmlAttribute("Player Variables")]
    public float curHealth;
    public float curMana;
    [XmlElement("Position")]
    public Vector3 position;
}

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]

    public float curHealth, maxHealth;
    public float curMana, maxMana;
    public float healthPerSecond = 1f;
    public float ManaPerSecond = 1f;

    [Header("Value Variables")]

    public Image radialHealthIcon;
    public Image radialManaIcon;

    [Header("Spawning Minions")]

    public GameObject zombie;
    public GameObject Skele;
    public GameObject ghost;

    public Camera cam;

    public LayerMask movementMask;

    public Vector3 playerPosition;

    [Header("Minions")]
    public GameObject[] minionObjectIndex;

    [Header("Cost Amount")]
    public int[] MinionPrices;
    public ScoreManager score;

    private void Start()
    {
        InvokeRepeating("Timer", 1, 1f);
    }
    public void MinionObjectIndex(int indexRef)
    {
        score.RemoveScore(MinionPrices[indexRef], ScoreType.Horde);
    }
    public void Update()
    {
        HealthChange();
        ManaChange();

        void HealthChange()
        {
            float amount = Mathf.Clamp01(curHealth / maxHealth);
            radialHealthIcon.fillAmount = amount;

            if (curHealth > 245)
            {
                curHealth = 245;
            }
            if (curHealth < 0)
            {
                curHealth = 0;
            }
        }
        void ManaChange()
        {
            float amount = Mathf.Clamp01(curMana / maxMana);
            radialManaIcon.fillAmount = amount;

            if (curMana > 10)
            {
                curMana = 10;
            }
            if (curMana < 0)
            {
                curMana = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            curMana -= 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            curHealth -= 5;
        }

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        for (int i = 0; i < MinionPrices.Length; i++)
        {
            if (score.GetScore(ScoreType.Horde) >= MinionPrices[i])
            {
                if (Input.GetKeyDown(KeyCode.Z) && (Input.GetMouseButton(1)))
                {
                    Vector3 wordPos;
                    Ray ray = Camera.main.ScreenPointToRay(mousePos);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000f))
                    {
                        wordPos = hit.point;
                    }
                    else
                    {
                        wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                    }
                    Instantiate(zombie, wordPos, Quaternion.identity);
                    MinionObjectIndex(i);
                }
                if (Input.GetKeyDown(KeyCode.X) && (Input.GetMouseButton(1)))
                {
                    Vector3 wordPos;
                    Ray ray = Camera.main.ScreenPointToRay(mousePos);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000f))
                    {
                        wordPos = hit.point;
                    }
                    else
                    {
                        wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                    }
                    Instantiate(Skele, wordPos, Quaternion.identity);
                    MinionObjectIndex(i);
                }
                if (Input.GetKeyDown(KeyCode.C) && (Input.GetMouseButton(1)))
                {
                    Vector3 wordPos;
                    Ray ray = Camera.main.ScreenPointToRay(mousePos);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000f))
                    {
                        wordPos = hit.point;
                    }
                    else
                    {
                        wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                    }
                    Instantiate(ghost, wordPos, Quaternion.identity);
                    MinionObjectIndex(i);
                }
            }
        }
    }
    private void Timer()
    {
        curHealth += healthPerSecond;
        curMana += ManaPerSecond;
    }
}

