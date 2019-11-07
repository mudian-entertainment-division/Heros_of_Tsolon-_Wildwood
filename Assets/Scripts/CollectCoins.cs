using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        ScoreManager.coinScore += 1;
        Destroy(gameObject);
    }
}
