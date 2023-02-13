using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private EnemySO enemySO;
    private EnemyController enemyController;
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _shootCooldown;

    public GameObject player;
    public Rigidbody2D bulletPrefab;
    public Transform spawnPoint;

    void Start()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
        enemySO = gameObject.GetComponent<EnemyController>().Enemy;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ShooterMovement();
    }

    private void ShooterMovement()
    {
        if (player == null) return;
        if (!_canShoot) return;

        Vector2 direction = (player.transform.position - transform.position);
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
        enemyRigidbody.rotation = angle;

        ShooterAttack();
    }

    private void ShooterAttack()
    {
        var rotation = (transform.localEulerAngles.z - 90) * Mathf.PI / 180;
        var bulletDirection = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));

        Rigidbody2D bulletRigidbody = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bulletRigidbody.velocity = -400 * Time.fixedDeltaTime * bulletDirection;

        StartCoroutine(ShootCoolDown(_shootCooldown));
    }

    private IEnumerator ShootCoolDown(float shootCoolDown)
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        _canShoot = true;
    }
}
