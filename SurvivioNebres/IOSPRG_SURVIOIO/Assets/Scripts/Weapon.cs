using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AmmoPickup.AmmoType ammoType; // Ammo type for this weapon
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point where bullets are instantiated
    public float bulletSpeed = 20f; // Speed of the bullet
    public float fireRate = 0.5f; // Rate of fire in seconds
    private float lastFireTime;
    

    public void Fire()
{
    if (Time.time >= lastFireTime + fireRate)
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Get the Rigidbody component
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            // Apply force to the bullet to make it move
            bulletRigidbody.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        Debug.Log("Bullet fired!");
        lastFireTime = Time.time; // Update last fire time
    }
}

     public void OnFireButtonClicked()
    {
        Fire();
    }
}