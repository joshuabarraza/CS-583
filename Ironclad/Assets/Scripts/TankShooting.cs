using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;
    private TankAudio tankAudio;

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

        // use upgraded bullet speed from GameManager
        rb.linearVelocity = firePoint.up * GameManager.Instance.bulletSpeed;

        if (tankAudio != null)
            tankAudio.PlayShoot();
    }
}
