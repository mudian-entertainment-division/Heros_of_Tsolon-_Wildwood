
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]

    public float curHealth, maxHealth;
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

    private void Start()
    {
        InvokeRepeating("Timer", 1, 1f);
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

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        if (Input.GetKey(KeyCode.Z) && (Input.GetMouseButtonDown(1)))
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
        }
        if (Input.GetKey(KeyCode.X) && (Input.GetMouseButtonDown(1)))
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
        }
        if (Input.GetKey(KeyCode.C) && (Input.GetMouseButtonDown(1)))
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
        }
    }
    private void Timer()
    {
        curHealth += healthPerSecond;
    }
}

