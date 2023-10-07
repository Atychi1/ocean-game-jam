using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
    public float maxLifeTime = 1.0f;


    private void Start()
    {
        Destroy(gameObject, maxLifeTime);  // Destroy the bullet after the specified time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Ignore collisions with the player
        if (collision.CompareTag("Player"))
        {
            return;
        }
            

        Destroy(gameObject);
    }




}
