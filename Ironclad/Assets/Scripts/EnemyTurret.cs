using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [Header("Settings")]
    public float detectionRange = 5f;
    public float fireRate = 2f;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public Transform turret;

    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || !player.gameObject.activeInHierarchy) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

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
        Vector2 direction = player.position - turret.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        turret.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Shoot()
    {
        if (firePoint == null) return;
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * bullet.GetComponent<EnemyBullet>().speed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}