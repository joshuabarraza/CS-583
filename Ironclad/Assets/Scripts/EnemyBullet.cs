using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;

        if (other.CompareTag("Player"))
            other.GetComponent<PlayerHealth>().TakeDamage(damage);

        Destroy(gameObject);
    }
}
