using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTower : MonoBehaviour
{
    public Text vomitText;
    public Text sawText;
    public Text rockText;
    public GameObject Vomit;
    public GameObject Saw;
    public GameObject Rock;

    public bool allowSawBuild = true;
    public bool allowVomitBuild = true;
    public bool allowRockBuild = true;

    [Header("Buildings")]
    public GameObject[] buildingObjectIndex;

    [Header("Cost Amount")]
    public int[] BuildingPrices;

    public ScoreManager score;

    private void Awake()
    {
        // All of these objects are set to off
        vomitText.gameObject.SetActive(false);
        sawText.gameObject.SetActive(false);
        rockText.gameObject.SetActive(false);
        Vomit.gameObject.SetActive(false);
        Saw.gameObject.SetActive(false);
        Rock.gameObject.SetActive(false);
    }
    private void Start()
    {
        score = ScoreManager.Instance;
    }

    public void BuildingObjectIndex(int indexRef)
    {
        score.RemoveScore(BuildingPrices[indexRef], ScoreType.Coin);
    }
    // When you enter into the zone...
    void OnTriggerEnter(Collider buildingTrigger)
    {
        for (int i = 0; i < BuildingPrices.Length; i++)
        {
            if (score.GetScore(ScoreType.Coin) >= BuildingPrices[i])
            {
                // finds tag of building
                if (buildingTrigger.tag == "Vomit")
                {
                    allowVomitBuild = true;

                    if (allowVomitBuild)
                    {
                        // All of these objects are set to on
                        vomitText.gameObject.SetActive(true);
                    }
                }
                if (Vomit.gameObject.activeSelf)
                {
                    vomitText.gameObject.SetActive(false);
                }

                // finds tag of building
                if (buildingTrigger.tag == "Saw")
                {
                    allowSawBuild = true;

                    if (allowSawBuild)
                    {
                        // All of these objects are set to on
                        sawText.gameObject.SetActive(true);
                    }
                }
                if (Saw.gameObject.activeSelf)
                {
                    sawText.gameObject.SetActive(false);
                }
                // finds tag of building
                if (buildingTrigger.tag == "Rock")
                {
                    allowRockBuild = true;

                    if (allowRockBuild)
                    {
                        // All of these objects are set to on
                        rockText.gameObject.SetActive(true);
                    }
                }
                if (Rock.gameObject.activeSelf)
                {
                    rockText.gameObject.SetActive(false);
                }
            }
        }
    }


    // When you exit into the zone...
    private void OnTriggerExit(Collider buildingTrigger)
    {
        for (int i = 0; i < BuildingPrices.Length; i++)
        {
            if (score.GetScore(ScoreType.Coin) >= BuildingPrices[i])
            {
                // finds tag of building
                if (buildingTrigger.tag == "Vomit")
                {
                    if (allowVomitBuild)
                    {
                        // All of these objects are set to off
                        vomitText.gameObject.SetActive(false);
                        allowVomitBuild = false;
                    }
                }
                // finds tag of building
                if (buildingTrigger.tag == "Saw")
                {
                    if (allowSawBuild)
                    {
                        // All of these objects are set to off
                        sawText.gameObject.SetActive(false);
                        allowSawBuild = false;
                    }
                }
                // finds tag of building
                if (buildingTrigger.tag == "Rock")
                {
                    if (allowRockBuild)
                    {
                        // All of these objects are set to off
                        rockText.gameObject.SetActive(false);
                        allowRockBuild = false;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < BuildingPrices.Length; i++)
        {
            if (score.GetScore(ScoreType.Coin) >= BuildingPrices[i])
            {
                // Text element will only be active when you are inside of a building trigger
                if (vomitText.gameObject.activeSelf)
                {
                    // If I press E
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (allowVomitBuild)
                        {
                            // Disable text element
                            vomitText.gameObject.SetActive(false);
                            // Enable Tower
                            Vomit.gameObject.SetActive(true);

                            allowVomitBuild = false;
                            BuildingObjectIndex(i);
                        }
                    }
                }
                if (sawText.gameObject.activeSelf)
                {
                    // If I press E
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        if (allowSawBuild)
                        {
                            // Disable text element
                            sawText.gameObject.SetActive(false);
                            // Enable Tower
                            Saw.gameObject.SetActive(true);

                            allowSawBuild = false;
                            BuildingObjectIndex(i);
                        }
                    }
                }
                if (rockText.gameObject.activeSelf)
                {
                    // If I press E
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        if (allowRockBuild)
                        {
                            // Disable text element
                            rockText.gameObject.SetActive(false);
                            // Enable Tower
                            Rock.gameObject.SetActive(true);

                            allowRockBuild = false;
                            BuildingObjectIndex(i);
                        }
                    }
                }
            }
        }
    }
}
