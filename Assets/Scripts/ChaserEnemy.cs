using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private EnemySO enemy;
    private bool _canChase = true;
    [SerializeField] private float coolDown = 0.5f;

    public GameObject player;

    void Start()
    {
        enemy = gameObject.GetComponent<EnemyController>().Enemy;
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
        enemyRigidbody.velocity = enemy.Speed * Time.deltaTime * direction;

        // TODO: Use a corotine to make the chasing movement slowy
    }

    private IEnumerator ChasingCoolDown(float coolDown)
    {
        _canChase = false;
        yield return new WaitForSeconds(coolDown);
        _canChase = true;
    }
}
