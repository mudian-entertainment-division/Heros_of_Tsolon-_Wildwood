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
    public GameObject scoreText;
    public GameObject enemiesLeftText;

    public static int coinScore;
    public static int hordeScore;
    public static int livesScore;
    public static int playerScore;

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

        scoreText.GetComponent<Text>().text = "Score: " + playerScore;

        enemiesLeftText.GetComponent<Text>().text = "Enemies Remaining: " + WaveSpawner.enemiesAlive;
    }
}
