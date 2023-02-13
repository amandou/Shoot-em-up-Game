using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static event Action<int> onScoreUpdate;
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemySO enemy;

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
        // TODO: Add VFX
        _animator.SetTrigger("Death");
        onScoreUpdate?.Invoke(GetEnemyPoints());
        Destroy(gameObject, 2f);
    }

    public EnemySO Enemy
    {
        get => enemy;
        set => enemy = value;
    }
}
