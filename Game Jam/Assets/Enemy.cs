using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Bullet bullet = GetComponent<Bullet>();
        if (bullet != null)
        {
            health = (health - damage);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        

    }
}
