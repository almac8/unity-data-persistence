using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuUI : MonoBehaviour
{
    public TMP_Text nameText;

    public void StartGame() {
      Player.Instance.PlayerName = nameText.text;
      SceneManager.LoadScene(1);
    }
}