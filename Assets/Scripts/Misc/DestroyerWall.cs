using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}