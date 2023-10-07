using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public LayerMask collisionLayer;   // The layer that triggers the health restore
    public float healthRestoreAmount = 20f;  // Customize the amount of health to restore

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on the specified layer
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Attempt to get the PlayerHealth component from the colliding object
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // If a PlayerHealth component is found, restore health
            if (playerHealth != null)
            {
                // Calculate the amount of health to restore, considering the max health
                float healthToRestore = Mathf.Min(healthRestoreAmount, playerHealth.maxHealth - playerHealth.health);

                if (healthToRestore > 0)
                {
                    playerHealth.IncreaseHealth(healthToRestore);
                    Destroy(gameObject); // Destroy the pickup after health is restored
                }
            }
        }
    }
}
