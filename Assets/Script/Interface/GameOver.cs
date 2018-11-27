using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;

    void OnEnable()
    {
        int waveSurvie = PlayerStat.Rounds - 1;
        wavesText.text="You survived: "+waveSurvie.ToString()+" waves";
        Time.timeScale = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerStat.Rounds = 0;
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");   
    }
}
