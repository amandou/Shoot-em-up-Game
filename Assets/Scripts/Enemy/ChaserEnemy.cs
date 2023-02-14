using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private EnemySO enemySO;
    private EnemyController enemyController;
    private bool _canChase = true;

    private GameObject player;
    public GameObject explosionPrefab;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyController = gameObject.GetComponent<EnemyController>();
        enemySO = gameObject.GetComponent<EnemyController>().Enemy;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ChaserMovement();
    }

    private void ChaserMovement()
    {
        if (player == null) return;
        if (!_canChase) return;

        Vector2 direction = (player.transform.position - transform.position);
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
        direction.Normalize();

        enemyRigidbody.rotation = angle;
        enemyRigidbody.velocity = enemySO.Speed * Time.deltaTime * direction;

        // TODO: Use a corotine to make the chasing movement slowy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _canChase = false;
            enemyController.Death();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
