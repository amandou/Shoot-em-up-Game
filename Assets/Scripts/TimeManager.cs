using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float timerLimit;
    
    private TextMeshProUGUI timerText;
    private float currentTime;


    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= timerLimit)
        {
            timerText.text = timerLimit.ToString();
            timerText.color = Color.red;
            enabled = false;
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
}
