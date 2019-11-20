using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : BuildingTower
{
    public GameObject canonTower;

    private void Awake()
    {
        canonTower.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canonTower.gameObject.SetActive(true);
        }
    }
}
