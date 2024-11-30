using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject pistolPrefab;
    [SerializeField] private GameObject sgPrefab; // Shotgun
    [SerializeField] private GameObject arPrefab; // Assault Rifle
    [SerializeField] private Button fireButton; // Reference to the fire button

    private GameObject currentWeapon; // This is the current weapon
    private PlayerAmmo playerAmmo;

    private void Start()
    {
        playerAmmo = GetComponent<PlayerAmmo>();
        currentWeapon = pistolPrefab; // Start with the pistol prefab

       
        fireButton.onClick.AddListener(Shoot);
    }

    private void Update()
    {
      
    }

    public void PickupWeapon(GameObject weaponPrefab)
    {
        // Simply set the current weapon to the picked up weapon prefab
        currentWeapon = weaponPrefab; // Update the current weapon to the new weapon prefab
    }

    public void Shoot()
{
    if (currentWeapon != null) // Check if currentWeapon is not null
    {
        Weapon weaponComponent = currentWeapon.GetComponent<Weapon>();
        if (weaponComponent != null && playerAmmo.GetCurrentAmmo(weaponComponent.ammoType) > 0)
        {
            weaponComponent.Fire(); // Call the Fire method on the weapon
            playerAmmo.AddAmmo(weaponComponent.ammoType, -1); // Decrease ammo by 1
        }
        else
        {
            Debug.Log("Out of ammo for this weapon!");
        }
    }
}
}