using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{   
    [SerializeField] private List<Transform> primaryWeaponSpawnPoints = new List<Transform>();
    [SerializeField] private List<Transform> secondaryWeaponSpawnPoints = new List<Transform>();
    [SerializeField] private bool _canShoot;

    public BulletSO singleShotBulet;
    public BulletSO tripleShotBulet;
    public Rigidbody2D bulletPrefab;

    private void Awake()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            TripleShoot();
        }
        else
        {
            SingleShoot();
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
                int angleOffset = -90;
                if (bulletSo.BulletName == "Triple")
                {
                    angleOffset = -180;
                }
                var rotation = (transform.localEulerAngles.z + angleOffset) * Mathf.PI / 180;
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
