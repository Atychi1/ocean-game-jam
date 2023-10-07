using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Image healthBar;

    void Start()
    {
        health = maxHealth;
        UpdateHealth(); // Update the health text on start
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyObjectsInSameLayer();
            Destroy(gameObject);
        }

        UpdateHealth(); // Update the health text whenever health changes
    }

    private void UpdateHealth()
    {
        healthBar.fillAmount = health / 100f;
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
    public void IncreaseHealth(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        UpdateHealth();
    }
}

