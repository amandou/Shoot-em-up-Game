using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static event Action<int> onScoreUpdate;


    [SerializeField] private EnemySO enemy;

    public int GetEnemyPoints()
    {
        return enemy.Points;
    }

    public void Death()
    {
        // TODO: Add VFX
        onScoreUpdate?.Invoke(GetEnemyPoints());
        gameObject.GetComponent<ShipStatus>().ChangeShipSpriteToDeath(0);
        Destroy(gameObject, 2f);
    }

    private void OnEnable()
    {
        EnemyHealth.onEnemyDeath += Death;
    }

    private void OnDisable()
    {
        EnemyHealth.onEnemyDeath -= Death;
    }
}
