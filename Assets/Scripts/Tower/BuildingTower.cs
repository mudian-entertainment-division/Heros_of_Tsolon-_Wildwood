using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTower : MonoBehaviour
{
    public Text textElement;
    public GameObject Tower;

    private void Awake()
    {
        textElement.gameObject.SetActive(false);
        Tower.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider BuildingTrigger)
    {
        textElement.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider BuildingTrigger)
    {
         textElement.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textElement.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                textElement.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Tower.gameObject.SetActive(true);
        }
    }
}
