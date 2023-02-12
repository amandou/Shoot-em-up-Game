using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private HealthBar healthBar;

    public static event Action<int> onScoreUpdate;

    protected override void InicializeStatus()
    {
        healthBar.InicializeHealthBar(maxHealth);
        base.InicializeStatus();
    }

    protected override void TakeDamage(int damage)
    {
        // TODO: Add VFX
        healthBar.UpdateHealthBar(maxHealth, health);
        Debug.Log("Enemy Take Damage");
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
                Debug.Log("Dano no inimigo");
                TakeDamage(1);
                break;
        }
    }
}