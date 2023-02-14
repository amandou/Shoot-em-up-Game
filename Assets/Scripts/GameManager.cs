using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _isPlayerDead;
    private bool _isTimeEnded;

    public GameObject endGamePanel;
    public static event Action onGameEnd;

    void Start()
    {
        SetStartGameStatus();
    }

    private void Update()
    {
        if (_isPlayerDead || _isTimeEnded)
        {
            EndGame();
            return;
        }
    }

    void SetStartGameStatus()
    {
        _isPlayerDead = false;
        _isTimeEnded = false;
        endGamePanel.SetActive(false);

    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        onGameEnd?.Invoke();
    }

    private void ChangePlayerStatus()
    {
        _isPlayerDead = true;
    }

    private void ChangeTimerStatus()
    {
        _isTimeEnded = true;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDie -= ChangePlayerStatus;
        TimeManager.onTimeEnd -= ChangeTimerStatus;
    }

    private void OnEnable()
    {
        PlayerController.onPlayerDie += ChangePlayerStatus;
        TimeManager.onTimeEnd += ChangeTimerStatus;
    }
}
