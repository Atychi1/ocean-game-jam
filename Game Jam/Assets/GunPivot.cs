using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    public Camera m_camera;

    public Transform gun_holder;
    public Transform fire_point;

    public GameObject bulletPrefab;

    public float fireRate = 0.5f;  // Time between shots in seconds
    private float nextFireTime = 0f;

    private void Update()
    {
        RotateGun();
        PlayerInput();
    }

    void RotateGun()
    {
        Vector2 distanceVector = (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)gun_holder.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

        // Smooth the rotation to avoid rapid flashing
        float smoothAngle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, angle, ref rotationVelocity, smoothTime);

        // Limit the rotation to avoid abrupt changes
        smoothAngle = Mathf.Clamp(smoothAngle, minAngle, maxAngle);

        transform.rotation = Quaternion.AngleAxis(smoothAngle, Vector3.forward);
    }

    float rotationVelocity;  // Velocity for smoothing rotation
    float smoothTime = 0.1f;  // Smoothing time for rotation
    float minAngle = -360f;   // Minimum allowed angle
    float maxAngle = 360f;    // Maximum allowed angle


    void PlayerInput() 
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FireBullet(mousePos, 5, 30f);
            nextFireTime = Time.time + 1f / fireRate;  // Update the next allowed fire time
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

            bullet.layer = LayerMask.NameToLayer("Player");

            if (bulletScript != null)
            {
                float speed = bulletScript.speed;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * speed;
            }
        }
    }

}
