﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int gold;
    public int waveNumber;
    public int escapedEnemies;
    public int maxAllowedEscapedEnemies = 5;
    public bool enemySpawningOver;
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;

    private bool gameOver;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!gameOver && enemySpawningOver)
        {
            //Check if there are no enemies left
            if (EnemyManager.Instance.Enemies.Count == 0)
            {
                OnGameWin();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }

    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound, Camera.main.transform.position);
        gameOver = true;
    }

    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void OnEnemyEscape()
    {
        escapedEnemies++;
        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
            OnGameLose();
        }
    }

    private void OnGameLose()
    {
        gameOver = true;

        AudioSource.PlayClipAtPoint(gameLoseSound, Camera.main.transform.position);
        EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
