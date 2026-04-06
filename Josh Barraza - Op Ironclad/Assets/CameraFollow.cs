using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;
    void LateUpdate()
    {
        Vector3 desired = new Vector3(
            target.position.x, 
            target.position.y,
            10f
            );
            transform.position - Vector3.Lerp(transform.position, desired, smoothSpeed);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
