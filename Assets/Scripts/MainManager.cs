using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Slider _sliderGameSession, _sliderSpawnEnemy;
    public static MainManager Instance;
    public int GameSessionTime, SpawnEnemyTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        MainManager.Instance.GameSessionTime = (int)_sliderGameSession.value;
        MainManager.Instance.SpawnEnemyTime = (int)_sliderSpawnEnemy.value;
    }

    public void GameSessionTimeSelected()
    {
        MainManager.Instance.GameSessionTime = (int)_sliderGameSession.value;
    }

    public void SpawnEnemyTimeSelected()
    {
        MainManager.Instance.SpawnEnemyTime = (int)_sliderSpawnEnemy.value;
    }
}
