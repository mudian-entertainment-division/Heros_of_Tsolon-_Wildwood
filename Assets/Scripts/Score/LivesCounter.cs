using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        // When the enmey gets the the end
        if (other.CompareTag("Enemy"))
        {
            // Life counter will increase
            ScoreManager.Instance.AddScore(1, ScoreType.Lives);
        }
    }
}
