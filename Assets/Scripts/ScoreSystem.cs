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
        scoreText.text = "Score\n" + score;
    }

    private void OnEnable()
    {
        EnemyController.onScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        EnemyController.onScoreUpdate -= UpdateScore;
    }
}
