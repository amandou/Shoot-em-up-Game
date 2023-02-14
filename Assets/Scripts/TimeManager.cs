using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float timerLimit;
    [SerializeField] private bool _isGameEnded;
    
    private TextMeshProUGUI timerText;
    private float currentTime;

    public static event Action onTimeEnd;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = startTime;
        _isGameEnded = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        EndTimer();
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = "Timer\n"+currentTime.ToString("0");
    }

    private void EndTimer()
    {
        if (currentTime <= timerLimit || _isGameEnded)
        {
            timerText.text = timerLimit.ToString();
            timerText.color = Color.red;
            enabled = false;
            onTimeEnd?.Invoke();
        }
    }

    private void ChangeGameStatus()
    {
        _isGameEnded = true;
    }

    private void OnDisable()
    {
        GameManager.onGameEnd -= ChangeGameStatus;
    }

    private void OnEnable()
    {
        GameManager.onGameEnd += ChangeGameStatus;
    }
}
