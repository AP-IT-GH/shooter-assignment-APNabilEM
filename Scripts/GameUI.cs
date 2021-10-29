using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class GameUI : MonoBehaviour
{
    public GameObject pausedGameUI;
    public GameObject gameOverGameUI;
    public GameObject winnerGameUI;
    bool isGameOver = false;
    void Start()
    {
        FindObjectOfType<WaypointProgressTracker>().lookAheadForTargetOffset = 1.5f;
        Time.timeScale = 1;
        pausedGameUI.SetActive(false);
        gameOverGameUI.SetActive(false);
        winnerGameUI.SetActive(false);
    }

    public void GameOver()
    {
        FindObjectOfType<WaypointProgressTracker>().lookAheadForTargetOffset = -1f;
        gameOverGameUI.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
    }

    public void Winner()
    {
        FindObjectOfType<WaypointProgressTracker>().lookAheadForTargetOffset = -1f;
        winnerGameUI.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
    }

    public void Pause()
    {
        FindObjectOfType<WaypointProgressTracker>().lookAheadForTargetOffset = -1f;
        pausedGameUI.SetActive(true);
        Time.timeScale = 0;
        if (isGameOver)
        {
            pausedGameUI.SetActive(false);
        }
    }

    public void Resume()
    {
        FindObjectOfType<WaypointProgressTracker>().lookAheadForTargetOffset = 1.5f;
        pausedGameUI.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
