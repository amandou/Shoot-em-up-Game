using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    public static event Action<int> onScoreUpdate;
    protected override void InicializeStatus()
    {
        base.InicializeStatus();
    }

    protected override void TakeDamage(int damage)
    {
        // TODO: Add VFX
        base.TakeDamage(1);
    }

    protected override void Kill()
    {
        // TODO: Add VFX
        int points = gameObject.GetComponent<EnemyController>().GetEnemyPoints();
        onScoreUpdate?.Invoke(points);
        base.Kill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PlayerBullet":
                TakeDamage(1);
                break;
        }
    }
}