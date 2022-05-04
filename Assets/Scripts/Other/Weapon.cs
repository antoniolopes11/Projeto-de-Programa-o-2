using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab = null;

    [SerializeField]
    private Transform shootPoint = null;

    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float shootTime = 3f;

    private bool canShoot = true;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), shootTime, shootTime);
    }

    private void Shoot()
    {
        if (canShoot)
        {
            Vector3 bulletVector = new Vector3(target.position.x - shootPoint.position.x, 
                target.position.y - shootPoint.position.y, target.position.z - shootPoint.position.z);
            GameObject bullet= Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (bulletVector * bulletSpeed).normalized;
        }
    }

    public void StopShooting()
    {
        canShoot = false;
        CancelInvoke(nameof(Shoot));
    }
}
