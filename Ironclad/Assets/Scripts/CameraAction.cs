using UnityEngine;

public class CameraAction : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target;           // drag Tank here
    public float smoothSpeed = 0.1f;   // lower = smoother, higher = snappier

    void LateUpdate()
    {
        if (target == null) return;

        // Follow target position, keep Z at -10 for 2D
        Vector3 desired = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed);
    }
}