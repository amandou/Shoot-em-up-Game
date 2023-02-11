using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public Transform shootTransform;

    [SerializeField] private float speed;

    [SerializeField] private List<Transform> primaryWeaponSpawnPoints = new List<Transform>();
    [SerializeField] private List<Transform> secondaryWeaponSpawnPoints = new List<Transform>();

    public BulletSO singleShotBulet;
    public BulletSO tripleShotBulet;

    private bool _canShoot = true;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //SingleShoot();
        TripleShoot();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement).normalized;

        PlayerRotation();

        playerRigidbody.velocity = new Vector2(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
    }

    private void PlayerRotation() 
    {
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, playerPosition.z - 135);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, playerPosition.z + 135);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, playerPosition.z + 45);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

    }

    private void SingleShoot()
    {
        Shoot(primaryWeaponSpawnPoints, singleShotBulet);
    }

    private void TripleShoot()
    {
        Shoot(secondaryWeaponSpawnPoints, tripleShotBulet);
    }

    private void Shoot(List<Transform> spawnPoints, BulletSO bulletSo)
    {
        if (_canShoot)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var rotation = (transform.localEulerAngles.z - 90) * Mathf.PI / 180;
                var bulletDirection = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));

                Rigidbody2D bulletRigidbody = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                bulletRigidbody.velocity = -bulletSo.Speed * Time.fixedDeltaTime * bulletDirection;
            }
            StartCoroutine(ShootCoolDown(bulletSo.CoolDown));
        }
    }

    private IEnumerator ShootCoolDown(float shootCoolDown)
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        _canShoot = true;
    }
}
