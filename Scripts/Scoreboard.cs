using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    int scoreMultiplier = 1;
    public int score;
    public Text scoreText;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score = score + scoreMultiplier;
        PlayerPrefs.SetInt("Score", score);
    }

    private void Update()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }
}
