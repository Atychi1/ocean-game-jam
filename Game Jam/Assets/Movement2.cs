using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2 : MonoBehaviour
{
    //i changed the movement script entirely to make the dash a little better
    //if you dont like it you can just change it back :)

    private float horizontal;
    private float vertical;  // Added vertical movement
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public GameObject bulletPrefab;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public float fireRate = 0.5f;  // Time between shots in seconds
    private float nextFireTime = 0f;

    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");  // Added vertical movement

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FireBullet(mousePos, 5, 30f);
            nextFireTime = Time.time + 1f / fireRate;  // Update the next allowed fire time
        }


        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);  // adjusted movement for vertical movement
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FireBullet(Vector3 targetPosition, int numBullets, float spreadAngle)
    {
        for (int i = 0; i < numBullets; i++)
        {
            float bulletAngle = -(spreadAngle / 2) + (i * (spreadAngle / (numBullets - 1)));
            Vector2 bulletDirection = Quaternion.Euler(0f, 0f, bulletAngle) * (targetPosition - (Vector3)transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                float speed = bulletScript.speed;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * speed;
            }
        }
    }
}



