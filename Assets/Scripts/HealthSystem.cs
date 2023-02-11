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

    private void Start()
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
        if (!canTakeDamage) return;
        Health -= damage;
        CheckDeathAndKill();
        InvencibilityCooldown(invencibilityCooldown);
    }

    protected virtual void CheckDeathAndKill()
    {
        if (Health > 0) return;
        Destroy(gameObject);
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

}
