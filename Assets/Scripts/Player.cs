using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public string PlayerName;
    public string highScoreName;
    public int highScore;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class HighScore {
      public string highScoreName;
      public int highScore;
    }

    public void LoadHighScore() {
      string path = Application.persistentDataPath + "/highscore.json";
      
      if(File.Exists(path)) {
        string json = File.ReadAllText(path);

        HighScore highScoreData = JsonUtility.FromJson<HighScore>(json);

        highScoreName = highScoreData.highScoreName;
        highScore = highScoreData.highScore;
      }
    }

    public void SaveHighScore() {
      HighScore highScoreData = new HighScore();

      highScoreData.highScoreName = highScoreName;
      highScoreData.highScore = highScore;

      string json = JsonUtility.ToJson(highScoreData);
      File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }
}