using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _heathBarSprite;

    public void InicializeHealthBar(int maxHealth)
    {
        _heathBarSprite.fillAmount = maxHealth;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _heathBarSprite.fillAmount = currentHealth/maxHealth;
    }
}
