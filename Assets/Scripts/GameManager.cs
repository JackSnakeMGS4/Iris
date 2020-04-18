﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    private bool gameplayStarted = false;
    public static bool startGameplay { get { return GameManager.GM.gameplayStarted; } }

    private bool gamePaused = false;
    public static bool pauseGame { get { return GameManager.GM.gamePaused; } }

    private void Awake()
    {
        GM = this;
    }

    public void StartGameplay()
    {
        gameplayStarted = true;
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;

        if (gamePaused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
}
