using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;

    // Shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;

    // Burst
    public int bulletsPerBurst = 3;
    public int currentBurst;

    // Spread (For accuraty of the weapons)
    public float spreadIntensity;

    // Bullet
    public GameObject bulletPrefeb;
    public Transform bulletSpawn;
    public float bulletVelocity = 30; //The speed of the bullet
    public float bulletPrefebLifeTime = 3f; // How long the bullet  exists

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefeb, bulletSpawn.position, Quaternion.identity);
        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        // Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefebLifeTime));


    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
