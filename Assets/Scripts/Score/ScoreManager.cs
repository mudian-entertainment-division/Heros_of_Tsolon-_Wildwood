using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public GameObject coinText;
    public GameObject hordeText;
    public GameObject livesText;

    public static int coinScore;
    public static int hordeScore;
    public static int livesScore;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Adds a one counter to all the game texts
        coinText.GetComponent<Text>().text = "" + coinScore;

        hordeText.GetComponent<Text>().text = "" + hordeScore;

        livesText.GetComponent<Text>().text = "Lives: " + livesScore;
    }
}
