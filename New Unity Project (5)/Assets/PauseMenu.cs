﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject StartMenuUI;

    public GameObject pauseMenuUI;

    public GameObject pauseButton;

    public GameObject RuleMenuUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        pauseButton.SetActive(false);
    }

    public void RuleMenu()
    {
        StartMenuUI.SetActive(false);
        RuleMenuUI.SetActive(true);
    }

    public void PrevStartMenu()
    {
        RuleMenuUI.SetActive(false);
        StartMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting game");
        SceneManager.LoadScene("MainScene");
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EGK2");
    }

    public void QuitGameGUI()
    {
        //Debug.Log("Quitting game");
        Application.Quit();
    }

}
