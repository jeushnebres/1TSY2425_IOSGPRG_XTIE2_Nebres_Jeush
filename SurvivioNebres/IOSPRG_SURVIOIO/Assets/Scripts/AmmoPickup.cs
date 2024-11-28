using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;

    public enum AmmoType
    {
        SGAmmo,
        ARAmmo,
        PistolAmmo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the ammo
        if (collision.CompareTag("Player"))
        {
            // Notify the player about the ammo pickup
            PlayerAmmo playerAmmo = collision.GetComponent<PlayerAmmo>();
            if (playerAmmo != null)
            {
                int ammoAmount = GetAmmoAmount(ammoType); // Get the amount based on ammo type
                playerAmmo.AddAmmo(ammoType, ammoAmount); // Add ammo to the player's inventory
                Destroy(gameObject); // Destroy the ammo pickup object
            }
        }
    }

    private int GetAmmoAmount(AmmoType type)
    {
        switch (type)
        {
            case AmmoType.PistolAmmo:
                return Random.Range(1, 9); // 1 to 8 bullets
            case AmmoType.SGAmmo:
                return Random.Range(1, 3); // 1 to 2 bullets
            case AmmoType.ARAmmo:
                return Random.Range(5, 16); // 5 to 15 bullets
            default:
                return 1; // Default case (shouldn't happen)
        }
    }
}