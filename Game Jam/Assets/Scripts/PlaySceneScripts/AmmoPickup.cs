using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;  // Customize the amount of ammo to add

    public LayerMask collisionLayer;  // Specify the layer for collision

    public GunPivot gunPivot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is on the specified layer
        if (((1 << other.gameObject.layer) & collisionLayer) != 0)
        {
            // Increase ammo when the correct layer collides with the pickup
            
            int remainingSpace = gunPivot.maxAmmo - gunPivot.currentAmmo;
            int ammoToAdd = Mathf.Min(ammoAmount, remainingSpace);

            if (ammoToAdd > 0)
            {
                gunPivot.currentAmmo += ammoToAdd;
                gunPivot.UpdateAmmoUI();
                Destroy(gameObject);  // Destroy the ammo pickup after collision
            }
            
            
        }
    }
}
