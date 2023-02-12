using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : HealthSystem
{
    [SerializeField]private HealthBar healthBar;
    [SerializeField] private Animator _animator;

    public static event Action onPlayerDeath;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        InicializeStatus();
    }

    protected override void InicializeStatus()
    {
        healthBar.InicializeHealthBar(maxHealth);
        base.InicializeStatus();
    }

    protected override void TakeDamage(int damage)
    {
        // TODO: Add VFX
        base.TakeDamage(damage);
        healthBar.UpdateHealthBar(health);

        if (health <= maxHealth * 0.5)
            _animator.SetTrigger("50PercentHealth");
        else if (health <= maxHealth * 0.75)
            _animator.SetTrigger("75PercentHealth");

    }

    protected override void Kill()
    {
        // TODO: Add VFX
        _animator.SetTrigger("Death");
        gameObject.GetComponent<PlayerController>().Death();
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
