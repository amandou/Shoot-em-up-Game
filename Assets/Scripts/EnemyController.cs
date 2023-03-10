using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private EnemySO enemy;
    [SerializeField] private GameObject deathAnimation;
    public static event Action<int> onScoreUpdate;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public int GetEnemyPoints()
    {
        return enemy.Points;
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        onScoreUpdate?.Invoke(GetEnemyPoints());
        Destroy(gameObject, 2f);
    }

    public EnemySO Enemy
    {
        get => enemy;
        set => enemy = value;
    }
}
