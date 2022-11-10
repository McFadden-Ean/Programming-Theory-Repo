using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string sessionName;
    public int sessionScore;
    public string highName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public int highScore;
    }
    public void SaveHighScore(int score, string name)
    {
        SaveData data = new SaveData();
        data.playerName = name;
        data.highScore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highName = data.playerName;
            highScore = data.highScore;
        }
    }
}
