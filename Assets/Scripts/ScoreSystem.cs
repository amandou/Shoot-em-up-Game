using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int score;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScore(int scoreToIncrease)
    {
        score += scoreToIncrease;
        scoreText.text = "Score\n\n" + score;
    }

    private void OnEnable()
    {
        PlayerBullet.onScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerBullet.onScoreUpdate -= UpdateScore;
    }
}
