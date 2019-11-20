using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTower : MonoBehaviour
{
    public Text textElement;
    public GameObject Tower;

    public bool allowBuild = true;

    private void Awake()
    {
        textElement.gameObject.SetActive(false);
        Tower.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider buildingTrigger)
    {
        if (buildingTrigger.tag == "Building")
        {
            textElement.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider buildingTrigger)
    {
        if (buildingTrigger.tag == "Building")
        {
            textElement.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Text element will only be active when you are inside of a building trigger
        if (textElement.gameObject.activeSelf)
        {
            // If I press E
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (allowBuild)
                {
                    // Disable text element
                    textElement.gameObject.SetActive(false);
                    // Enable Tower
                    Tower.gameObject.SetActive(true);

                    allowBuild = false;
                }       
            }
        }
    }
}
