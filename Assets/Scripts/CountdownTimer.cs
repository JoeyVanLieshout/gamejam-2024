using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 10f;

    [SerializeField] Text countdownText;
    [SerializeField] public GameObject Menu1;
    [SerializeField] public GameObject Menu2;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0) 
        {
            Time.timeScale = 0f;
            Menu1.SetActive(false);
            Menu2.SetActive(true);
        }
    }
}
