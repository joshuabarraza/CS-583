using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 4f;
    public float rotateSpeed = 150f;

    [Header("References")]
    public Transform turret; // drag Turret child object here in Inspector

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotate turret to face mouse cursor
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorld - turret.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        turret.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void FixedUpdate()
    {
        // Move forward/backward relative to tank facing direction
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        rb.MovePosition(rb.position + (Vector2)transform.up * move * moveSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation - turn * rotateSpeed * Time.fixedDeltaTime);
    }
}