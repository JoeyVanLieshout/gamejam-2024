using System;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public int score = 0; // Initialize score to zero
    public Text scoreText; // Reference to the Text object to display the score

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        UpdateScoreText(); // Update the score text when the game starts
    }

    private void Update()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Cat Detected");
            score++; // Increase score by 1 when a "CatDeactivate" object enters the collider
            UpdateScoreText(); // Update the score text
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the Text object with the current score
        }
    } 
}