using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController Instance;
    [SerializeField] private float timerTime;
    [SerializeField] private float StartTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        timerTime = StartTime;
    }

    public void AddTime(float time)
    {
        timerTime += time;
    }

    public void Update()
    {
        timerTime -= Time.deltaTime;
    }
}
