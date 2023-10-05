using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled; //this makes a fun counter that shows you when the enemy's killed!
    [SerializeField] float health, maxHealth = 100f;


    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
