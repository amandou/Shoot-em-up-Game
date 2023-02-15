using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator _animator;
    private EnemySO enemy;

    private new void Start()
    {
        enemy = gameObject.GetComponent<EnemyController>().Enemy;
        _animator = GetComponent<Animator>();
        InicializeStatus();
    }

    protected override void InicializeStatus()
    {
        base.InicializeStatus();
        healthBar.InicializeHealthBar(maxHealth);
    }

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.UpdateHealthBar(health);

        if (health <= maxHealth * 0.5)
            _animator.SetTrigger("50PercentHealth");
        else if (health <= maxHealth * 0.75)
            _animator.SetTrigger("75PercentHealth");
    }

    protected override void Kill()
    {
        base.Kill();
        _animator.SetTrigger("Death");
        gameObject.GetComponent<EnemyController>().Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            int damage = collision.gameObject.GetComponent<PlayerBullet>().GetBulletDamage();
            TakeDamage(damage);
        }
        
    }
}