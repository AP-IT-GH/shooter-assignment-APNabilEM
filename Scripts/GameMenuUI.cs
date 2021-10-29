using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    public GameObject manualControlScreen;

    void Start()
    {
        manualControlScreen.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ManualControls()
    {
        manualControlScreen.SetActive(true);
    }

    public void ExitManualControls()
    {
        manualControlScreen.SetActive(false);
    }
}
