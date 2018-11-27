using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BtnStart()
    {
        SceneManager.LoadScene("Scenes/Game");
        Time.timeScale = 1f;
    }

    public void BtnExit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

}
