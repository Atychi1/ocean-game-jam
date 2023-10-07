using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled; // This makes a fun counter that shows you when the enemy's killed!
    [SerializeField] float health, maxHealth = 100f;
    public LayerMask layerMask;
    private float damageInterval = 0.2f;
    public float damage = 5f;

    public PlayerHealth playerHealth;

    private void Start()
    {
        health = maxHealth;
        StartCoroutine(ApplyDamageOverTime());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    private void CheckCollisionsWithLayer()
    {
        Vector2 center = transform.position;
        Vector2 halfExtents = transform.localScale * 0.5f;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, halfExtents, 0f, layerMask);

        foreach (Collider2D collider in colliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth(damage);
            }
        }
    }

    private IEnumerator ApplyDamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);
            CheckCollisionsWithLayer();
        }
    }
}
