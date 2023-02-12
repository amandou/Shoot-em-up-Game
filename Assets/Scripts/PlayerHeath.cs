using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : HealthSystem
{
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
