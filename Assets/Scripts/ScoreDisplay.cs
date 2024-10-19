using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public PlayerBehavior playerBehavior; // Reference to the PlayerBehavior script
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        playerBehavior = FindObjectOfType<PlayerBehavior>();
        UpdateScoreDisplay();
    }

    private void Update()
    {
        
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (playerBehavior != null)
        {
            scoreText.text = "Score: " + playerBehavior.currentScore.ToString();
        }
    }
}