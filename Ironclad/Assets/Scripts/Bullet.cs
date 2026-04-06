using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;

        // Play appropriate sound based on what was hit
        if (other.CompareTag("Crate"))
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