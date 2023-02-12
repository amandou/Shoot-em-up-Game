using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : HealthSystem
{
    [SerializeField]private HealthBar healthBar;

    private void Start()
    {
       
    }

    protected override void InicializeStatus()
    {
        healthBar.InicializeHealthBar(maxHealth);
        base.InicializeStatus();
    }

    protected override void TakeDamage(int damage)
    {
        // TODO: Add VFX
        healthBar.UpdateHealthBar(maxHealth, damage);
        base.TakeDamage(damage);
    }

    protected override void Kill()
    {
        // TODO: Add VFX
        base.Kill();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "EnemyBullet":
                TakeDamage(1);
                break;
            case "Enemy":
                TakeDamage(1);
                break;
        }
    }

}
