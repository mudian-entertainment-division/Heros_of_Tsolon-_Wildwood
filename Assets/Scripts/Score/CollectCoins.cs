using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{
    public LayerMask Coins;

    public int Wallet = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.coinScore += Wallet + 1;
            Destroy(gameObject);
        }
    }
}
