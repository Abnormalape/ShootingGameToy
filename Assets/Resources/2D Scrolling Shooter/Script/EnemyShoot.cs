using System;
using System.Runtime.InteropServices;
using Unity;
using UnityEngine;
class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float shootInterval = 1.0f;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;

    private Transform refPlayer;
    private float elapsedTime = 0f;
    private void Awake()
    {
        refPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }
    private void Shoot()
    {
        if (refPlayer == null)
        {
            return;
        }
        if (transform.position.y < refPlayer.transform.position.y)
        {
            return;
        }

        Vector3 direction = refPlayer.position - transform.position;
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
