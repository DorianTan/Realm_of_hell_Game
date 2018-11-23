﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    public GameObject ui;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }	
	}

    public void Toggle() // marche pour le bouton "continue"
    {
        ui.SetActive(!ui.activeSelf); //plus simple pour basculer d'un état à l'autre

        if (ui.activeSelf)
	    {
        Time.timeScale=0f;
	    }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle(); //être sûr que le temps est arrêter
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
