using UnityEngine;
using System.Collections;

using System.Xml.Serialization;
using System.IO;

[XmlRoot("Game")]
public class GameData
{
    [XmlElement("Player")]
    public PlayerData playerData = new PlayerData();
    [XmlElement("Enemy")]
    public EnemyData enemyData = new EnemyData();
    [XmlElement("Score")]
    public ScoreData scoreData = new ScoreData();
}

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public string fileName = "PlayerData";
    private string fullPath;

    public GameData gameData;

    public PlayerHandler playerHandler;
    public Enemy enemy;

    private void OnDestroy()
    {
        SaveGame();
    }

    private void Start()
    {
        if (playerHandler == null)
        {
            playerHandler = FindObjectOfType<PlayerHandler>();
        }
        if (enemy == null)
        {
            enemy = FindObjectOfType<Enemy>();
        }

        fullPath = Application.persistentDataPath + "/" + fileName + ".xml";
        if(File.Exists(fullPath))
        {
            // Load the information
            gameData = Load(fullPath);

            // Apply the information
            ScoreManager.Instance.data = gameData.scoreData;
            playerHandler.transform.position = gameData.playerData.position;
            playerHandler.curHealth = gameData.playerData.curHealth;
            playerHandler.curMana = gameData.playerData.curMana;
            enemy.transform.position = gameData.enemyData.enemyPosition;
            enemy.Health = gameData.enemyData.Health;
            enemy.Damage = gameData.enemyData.Damage;

            // Update UI here

        }
        else
        {
            gameData = new GameData();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        // Apply new player data
        gameData.playerData.position = playerHandler.transform.position;
        gameData.playerData.curHealth = playerHandler.curHealth;
        gameData.playerData.curMana = playerHandler.curMana;

        gameData.enemyData.enemyPosition = enemy.transform.position;
        gameData.enemyData.Health = enemy.Health;
        gameData.enemyData.Damage = enemy.Damage;

        gameData.scoreData = ScoreManager.Instance.data;

        // Save the Information
        Save(fullPath, gameData);
    }

    public void Save(string path, GameData data)
    {
        var serializer = new XmlSerializer(typeof(GameData));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, data);
        }
    }
    public static GameData Load(string path)
    {
        var serializer = new XmlSerializer(typeof(GameData));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as GameData;
        }
    }
}
