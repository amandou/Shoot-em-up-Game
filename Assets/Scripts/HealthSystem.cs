using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [SerializeField] private bool canTakeDamage;
    [SerializeField] private bool isDead;
    [SerializeField] protected float invencibilityCooldown;

    protected virtual void Start()
    {
        InicializeStatus();
    }

    protected virtual void InicializeStatus()
    {
        health = maxHealth;
        canTakeDamage = true;
        isDead = false;
    }

    protected virtual void TakeDamage(int damage)
    {
        if (!canTakeDamage || isDead) return;
        Health -= damage;
        CheckDeath();
        StartCoroutine(InvencibilityCooldown(invencibilityCooldown));
    }

    protected virtual void CheckDeath()
    {
        if (Health > 0) return;
        Kill();
    }

    protected virtual void Kill()
    {
        isDead = true;
        canTakeDamage = false;
    }

    private IEnumerator InvencibilityCooldown(float invencibilityCooldown)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invencibilityCooldown);
        canTakeDamage = true;
    }
    
    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }

    public bool CanTakeDamage
    {
        get => canTakeDamage;
        set => canTakeDamage = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
}
