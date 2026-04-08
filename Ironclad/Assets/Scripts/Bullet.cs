using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            if (eh != null) eh.TakeDamage(GameManager.Instance.bulletDamage);
        }
        else if (other.CompareTag("Crate"))
        {
            SoundManager.Instance.PlaySound(
                SoundManager.Instance.crateHitClip,
                transform.position,
                SoundManager.Instance.crateHitVolume
            );
        }
        else if (other.CompareTag("Wall"))
        {
            SoundManager.Instance.PlaySound(
                SoundManager.Instance.wallHitClip,
                transform.position,
                SoundManager.Instance.wallHitVolume
            );
        }

        Destroy(gameObject);
    }
}
