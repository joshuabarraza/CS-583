using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] waypoints;        // set patrol points in Inspector
    public float moveSpeed = 2f;
    public float waypointTolerance = 0.1f; // how close to reach a waypoint

    [Header("Combat Settings")]
    public float detectionRange = 5f;
    public float fireRate = 2f;
    public int damage = 1;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;

    private int currentWaypoint = 0;
    private bool movingForward = true;
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
            // Player detected — stop patrolling, aim and shoot
            AimAtPlayer();

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            // No player detected — patrol waypoints
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypoint];
        Vector2 direction = (target.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.position);

        // Move toward current waypoint
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Rotate body to face movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Check if waypoint reached
        if (distance <= waypointTolerance)
        {
            // Ping pong between waypoints
            if (movingForward)
            {
                if (currentWaypoint < waypoints.Length - 1)
                    currentWaypoint++;
                else
                {
                    movingForward = false;
                    currentWaypoint--;
                }
            }
            else
            {
                if (currentWaypoint > 0)
                    currentWaypoint--;
                else
                {
                    movingForward = true;
                    currentWaypoint++;
                }
            }
        }
    }

    void AimAtPlayer()
    {
        // Rotate to face player
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

    // Visualize detection range and waypoint path in Scene view
    void OnDrawGizmosSelected()
    {
        // Detection range circle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Patrol path lines
        if (waypoints == null || waypoints.Length < 2) return;
        Gizmos.color = Color.yellow;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}