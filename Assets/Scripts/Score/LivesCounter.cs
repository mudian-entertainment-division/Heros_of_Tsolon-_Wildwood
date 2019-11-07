using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ScoreManager.livesScore += 1;
    }
}
