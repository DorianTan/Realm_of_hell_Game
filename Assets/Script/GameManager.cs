using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject winGameUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (Input.GetKeyDown("e")||PlayerStat.Lives <= 0 )
        {
            LoseGame();
        }

        if (Input.GetKeyDown("w")|| PlayerStat.Rounds == 6)
        {
            WinGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void LoseGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
    void WinGame()
    {
        gameEnded = true;
        winGameUI.SetActive(true);
    }

}


