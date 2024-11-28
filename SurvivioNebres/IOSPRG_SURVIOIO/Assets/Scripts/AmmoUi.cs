using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static AmmoPickup;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI sgAmmoText; // UI Text for SG Ammo
    public TextMeshProUGUI arAmmoText; // UI Text for AR Ammo
    public TextMeshProUGUI pistolAmmoText; // UI Text for Pistol Ammo

    private PlayerAmmo playerAmmo;

    private void Start()
    {
        playerAmmo = FindObjectOfType<PlayerAmmo>();
        UpdateAmmoUI();
    }

    private void Update()
    {
        // This can be optimized to only update when ammo changes, but for simplicity, we will update every frame
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        sgAmmoText.text = "SG: " + playerAmmo.GetCurrentAmmo(AmmoType.SGAmmo);
        arAmmoText.text = "AR: " + playerAmmo.GetCurrentAmmo(AmmoType.ARAmmo);
        pistolAmmoText.text = "Pistol: " + playerAmmo.GetCurrentAmmo(AmmoType.PistolAmmo);
    }
}