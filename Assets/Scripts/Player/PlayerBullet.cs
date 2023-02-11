using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public static event Action<int> onScoreUpdate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int points = collision.gameObject.GetComponent<EnemyController>().getEnemySO().Points;
            onScoreUpdate?.Invoke(points);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
