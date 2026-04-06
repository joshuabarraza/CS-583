using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [Header("Settings")]
    public float detectionRange = 5f;   // how far it can see the player
    public float fireRate = 2f;          // seconds between shots
    public GameObject enemyBulletPrefab;
    public Transform firePoint;

    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || !player.gameObject.activeInHierarchy) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Only act if player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            AimAtPlayer();

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void AimAtPlayer()
    {
        // Rotate turret to face player
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Shoot()
    {
        if (firePoint == null) return;
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * bullet.GetComponent<EnemyBullet>().speed;
    }

    // Draw detection range in Scene view for easy tuning
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}