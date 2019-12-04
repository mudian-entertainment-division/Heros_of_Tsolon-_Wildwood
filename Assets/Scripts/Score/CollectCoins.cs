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
            // If coin is collected.. Adds 1 to the coin text and destroys the object
            ScoreManager.Instance.AddScore(Wallet + 1, ScoreType.Coin);
            
            Destroy(gameObject);
        }
    }
}
