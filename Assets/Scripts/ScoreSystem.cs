using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public int score = 0; // Initialize score to zero
    public Text scoreText; // Reference to the Text object to display the score
    public Text scoreText2;
    [SerializeField] public GameObject Emblem1;
    [SerializeField] public GameObject Emblem2;
    [SerializeField] public GameObject Emblem3;
    [SerializeField] public GameObject Emblem4;
    [SerializeField] public GameObject Emblem5;

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

        if(score == 0)
        {
            UnityEngine.Debug.Log("emblem1");
            Emblem1.SetActive(true);
            Emblem5.SetActive(false);
            Emblem3.SetActive(false);
            Emblem4.SetActive(false);
            Emblem2.SetActive(false);
        }
        else if(score == 20)
        {
            UnityEngine.Debug.Log("emblem2");
            Emblem2.SetActive(true);
            Emblem5.SetActive(false);
            Emblem3.SetActive(false);
            Emblem4.SetActive(false);
            Emblem1.SetActive(false);
        }
        else if(score == 40)
        {
            UnityEngine.Debug.Log("emblem3");
            Emblem3.SetActive(true);
            Emblem5.SetActive(false);
            Emblem4.SetActive(false);
            Emblem2.SetActive(false);
            Emblem1.SetActive(false);

        }
        else if(score == 60) {
            UnityEngine.Debug.Log("emblem4");
            Emblem4.SetActive(true);
            Emblem5.SetActive(false);
            Emblem3.SetActive(false);
            Emblem2.SetActive(false);
            Emblem1.SetActive(false);
        }
        else if(score == 80)
        {
            UnityEngine.Debug.Log("emblem5");
            Emblem5.SetActive(true);
            Emblem4.SetActive(false);
            Emblem3.SetActive(false);
            Emblem2.SetActive(false);
            Emblem1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Cat Detected");
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

        if (scoreText2 != null)
        {
            scoreText2.text = "Score: " + score; // Update the Text object with the current score
        }

        
    } 
}