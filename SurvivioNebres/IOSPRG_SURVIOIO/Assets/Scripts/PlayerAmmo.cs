using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AmmoPickup;

public class PlayerAmmo : MonoBehaviour
{
    private Dictionary<AmmoType, int> ammoCounts = new Dictionary<AmmoType, int>();

    // Constructor to initialize ammo counts
    private void Start()
    {
        foreach (AmmoType type in System.Enum.GetValues(typeof(AmmoType)))
        {
            ammoCounts[type] = 0; // Initialize each ammo type count to 0
        }
    }

    public void AddAmmo(AmmoType type, int amount)
    {
        if (ammoCounts.ContainsKey(type))
        {
            ammoCounts[type] += amount; // Add the specified amount to the appropriate ammo type
            Debug.Log($"Picked up {amount} of {type}! Current {type} ammo: {ammoCounts[type]}");
        }
    }

    public int GetCurrentAmmo(AmmoType type)
    {
        return ammoCounts.ContainsKey(type) ? ammoCounts[type] : 0;
    }
}