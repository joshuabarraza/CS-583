using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;
    private TankAudio tankAudio; // reference to audio script

    void Start()
    {
        tankAudio = GetComponent<TankAudio>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * bulletSpeed;

        // Play shoot sound
        if (tankAudio != null)
            tankAudio.PlayShoot();
    }
}