using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _heathBarSprite;
    private float _maxHealth; 

    public void InicializeHealthBar(int maxHealth)
    {
        _heathBarSprite.fillAmount = maxHealth;
        _maxHealth = maxHealth;
    }

    public void UpdateHealthBar(int currentHealth)
    {
        _heathBarSprite.fillAmount = currentHealth/_maxHealth;
    }
}
