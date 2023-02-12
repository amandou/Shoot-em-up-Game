using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    private SpriteRenderer _shipSprite;
    [SerializeField] private List<Sprite> spriteStatus = new List<Sprite>();

    private void Start()
    {
        _shipSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeShipSprite();
    }

    public void ChangeShipSpriteToDeath(int spriteNumber)
    {
        _shipSprite.sprite = spriteStatus[spriteNumber];
    }

    public void ChangeShipSprite()
    {
        int health = gameObject.GetComponent<EnemyHealth>().Health;
        int maxHealth = gameObject.GetComponent<EnemyHealth>().MaxHealth;

        if (health <= maxHealth * 0.5)
            _shipSprite.sprite = spriteStatus[1];
        else if (health <= maxHealth * 0.75 )
            _shipSprite.sprite = spriteStatus[2];
    }



}
