using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ScoreType
{
    Coin,
    Horde,
    Lives,
    Player
}

[System.Serializable]
public class ScoreData
{
    public int coinScore;
    public int hordeScore;
    public int livesScore;
    public int playerScore;
}

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Text coinText;
    public Text hordeText;
    public Text livesText;
    public Text scoreText;
    public Text enemiesLeftText;

    public ScoreData data = new ScoreData();

    void Update()
    {
        // Adds a one counter to all the game texts
        coinText.text = "" + data.coinScore;

        hordeText.text = "" + data.hordeScore;

        livesText.text = "Lives: " + data.livesScore;

        scoreText.text = "Score: " + data.playerScore;

        enemiesLeftText.text = "Enemies Remaining: " + WaveSpawner.Instance.EnemiesAlive;
    }

    public void CheckHighScore()
    {
        // if data.playerScore < playerScore
    }

    public void AddScore(int scoreToAdd, ScoreType type)
    {
        switch (type)
        {
            case ScoreType.Coin: data.coinScore += scoreToAdd; return;
            case ScoreType.Horde: data.hordeScore += scoreToAdd; return;
            case ScoreType.Lives: data.livesScore += scoreToAdd; return;
            case ScoreType.Player: data.playerScore += scoreToAdd; return;
        }
    }
    public void RemoveScore(int scoreToRemove, ScoreType type)
    {
        switch (type)
        {
            case ScoreType.Coin: data.coinScore -= scoreToRemove; return;
            case ScoreType.Horde: data.hordeScore -= scoreToRemove; return;
            case ScoreType.Lives: data.livesScore -= scoreToRemove; return;
            case ScoreType.Player: data.playerScore -= scoreToRemove; return;
        }
    }

    public int GetScore(ScoreType type)
    {
        switch (type)
        {
            case ScoreType.Coin: return data.coinScore;
            case ScoreType.Horde: return data.hordeScore;
            case ScoreType.Lives: return data.livesScore;
            case ScoreType.Player: return data.playerScore;
        }
        // Otherwise Error
        return -1;
    }
}
