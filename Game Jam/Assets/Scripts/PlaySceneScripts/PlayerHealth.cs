using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;

    public TextMeshProUGUI healthText; // Reference to the TextMeshPro component

    void Start()
    {
        health = maxHealth;
        UpdateHealthText(); // Update the health text on start
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyObjectsInSameLayer();
            Destroy(gameObject);
        }

        UpdateHealthText(); // Update the health text whenever health changes
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    private void DestroyObjectsInSameLayer()
    {
        int playerLayer = gameObject.layer;

        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.layer == playerLayer)
            {
                Destroy(obj);
            }
        }
    }
}

