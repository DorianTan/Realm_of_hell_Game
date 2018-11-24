using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI wavesText;

   // private int waveSurvie = PlayerStat.Rounds - 1;

    void OnEnable()
    {
        wavesText.text="You survive: "+PlayerStat.Rounds.ToString()+" waves";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerStat.Rounds = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
        PlayerStat.Rounds = 0;
        Time.timeScale = 1;
    }
}
