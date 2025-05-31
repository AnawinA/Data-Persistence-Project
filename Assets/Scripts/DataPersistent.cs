using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistent : MonoBehaviour
{
    public static DataPersistent Instance;
    private int _bestScore;
    public int BestScore
    {
        get => _bestScore;
        set => _bestScore = (value > _bestScore) ? value : _bestScore;
    }

    public string playerName;
    public string bestPlayerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadGame();
    }



    class GameData
    {
        public GameData(int bestScore, string bestPlayerName)
        {
            this.bestScore = bestScore;
            this.bestPlayerName = bestPlayerName;
        }

        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveGame()
    {
        GameData gameData = new GameData(BestScore, playerName);
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/save_game.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/save_game.json";
        if (File.Exists(path))
        {
            string json =  File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            _bestScore = gameData.bestScore;
            bestPlayerName = gameData.bestPlayerName;
        }
    }
}
