using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTower : MonoBehaviour
{
    public Text flameText;
    public Text sawText;
    public GameObject Flame;
    public GameObject Saw;

    public bool allowBuild = false;

    private void Awake()
    {
        flameText.gameObject.SetActive(false);
        sawText.gameObject.SetActive(false);
        Flame.gameObject.SetActive(false);
        Saw.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider buildingTrigger)
    {
        if (ScoreManager.coinScore <= 2)
        {
            allowBuild = true;
            if (buildingTrigger.tag == "Building")
            {
                if (allowBuild)
                {
                    flameText.gameObject.SetActive(true);
                    sawText.gameObject.SetActive(true);
                }
            }
        }

    }

    private void OnTriggerExit(Collider buildingTrigger)
    {
        if (buildingTrigger.tag == "Building")
        {
            if (allowBuild)
            {
                flameText.gameObject.SetActive(false);
                sawText.gameObject.SetActive(false);
                allowBuild = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Text element will only be active when you are inside of a building trigger
        if (flameText.gameObject.activeSelf)
        {
            // If I press E
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (allowBuild)
                {
                    // Disable text element
                    flameText.gameObject.SetActive(false);
                    // Enable Tower
                    Flame.gameObject.SetActive(true);

                    allowBuild = false;
                }       
            }
        }
        if (sawText.gameObject.activeSelf)
        {
            // If I press E
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (allowBuild)
                {
                    // Disable text element
                    sawText.gameObject.SetActive(false);
                    // Enable Tower
                    Saw.gameObject.SetActive(true);

                    allowBuild = false;
                }
            }
        }
    }
}
