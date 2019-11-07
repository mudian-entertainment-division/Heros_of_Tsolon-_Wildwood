using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject coinText;
    public GameObject hordeText;

    public static int coinScore;
    public static int hordeScore;

    void Update()
    {
        coinText.GetComponent<Text>().text = "" + coinScore;

        hordeText.GetComponent<Text>().text = "" + hordeScore;
    }
}
