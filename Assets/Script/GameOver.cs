using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerStat.Rounds = 0;
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }
}
