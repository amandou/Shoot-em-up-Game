using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public Transform shootTransform;

    [SerializeField] private float speed;
    [SerializeField] private float rotation;
    [SerializeField] private float shootCoolDown;

    private bool _canShoot = true;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SingleShoot();
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
        Shoot();
    }

    private void Shoot()
    {
        if (_canShoot)
        {
            var rotation = (transform.localEulerAngles.z - 90) * Mathf.PI / 180;
            var bulletVelocity = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
            Rigidbody2D bulletRigidbody = Instantiate(bulletPrefab, shootTransform.position, Quaternion.identity);
            bulletRigidbody.velocity = -100 * Time.fixedDeltaTime * bulletVelocity;
            StartCoroutine(ShootCoolDown());
        }
    }

    private IEnumerator ShootCoolDown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        _canShoot = true;
    }
    
}
