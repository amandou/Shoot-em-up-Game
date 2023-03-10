using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    [SerializeField]private HealthBar healthBar;
    [SerializeField] private Animator _animator;

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
        base.TakeDamage(damage);
        healthBar.UpdateHealthBar(health);

        if (health <= maxHealth * 0.5)
            _animator.SetTrigger("50PercentHealth");
        else if (health <= maxHealth * 0.75)
            _animator.SetTrigger("75PercentHealth");

    }

    protected override void Kill()
    {
        _animator.SetTrigger("Death");
        gameObject.GetComponent<PlayerController>().Death();
        base.Kill();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                TakeDamage(1);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

}
