using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]

    public float curHealth, maxHealth;
    //Health regen time
    public float healthPerSecond = 1f;

    [Header("Value Variables")]

    public Image radialHealthIcon;

    [Header("Damage Effect Variables")]

    public Image damageImage;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1, 1, 0, 0.2f);
    bool damaged;

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

    private void Start()
    {
        InvokeRepeating("Timer", 1, 1f);
    }
    public void MinionObjectIndex(int indexRef)
    {
        //Score is affected by how many minions you have
        ScoreManager.hordeScore -= MinionPrices[indexRef];
    }
    public void Update()
    {
        HealthChange();

        void HealthChange()
        {
            float amount = Mathf.Clamp01(curHealth / maxHealth);
            radialHealthIcon.fillAmount = amount;

            if (curHealth > 245)
            {
                curHealth = 245;
            }
        }
#if Unity_Editor
        //Test button to see if damage works
        if (Input.GetKeyDown(KeyCode.A))
        {
            damaged = true;
            curHealth -= 5;
        }
#endif
        //Screen Flashes when damaged
        if (damaged)
        {
            damageImage.color = flashColor;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //Locates mouse for minion control
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        for (int i = 0; i < MinionPrices.Length; i++)
        {
            if (ScoreManager.hordeScore >= MinionPrices[i])
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
    }
}

