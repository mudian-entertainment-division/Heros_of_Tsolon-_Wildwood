using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HordeCounter : MonoBehaviour
{
    public static int score;
    public static Text scoreDisplay;

    private void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        InvokeRepeating("Timer", 1, 0.25f);
    }

    public static void Increase()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
