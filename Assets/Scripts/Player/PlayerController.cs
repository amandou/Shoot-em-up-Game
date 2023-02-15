using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool _isDead;
    private Rigidbody2D playerRigidbody;

    public static event Action onPlayerDie;

    void Start()
    {
        _isDead = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isDead) return;
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

    public void Death()
    {
        _isDead = true;
        onPlayerDie?.Invoke();
        Destroy(gameObject, 2f);
    }
}
