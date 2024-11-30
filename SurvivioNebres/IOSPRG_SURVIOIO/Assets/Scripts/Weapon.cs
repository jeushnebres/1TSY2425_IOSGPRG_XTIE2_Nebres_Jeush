using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AmmoPickup.AmmoType ammoType; // Ammo type for this weapon
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point where bullets are instantiated
    public float bulletSpeed = 20f; // Speed of the bullet



    public void Fire()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

    }


     public void OnFireButtonClicked()
    {
        Fire();
    }
}