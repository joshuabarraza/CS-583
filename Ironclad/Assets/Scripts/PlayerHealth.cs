using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only take damage from enemy bullets
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        SoundManager.Instance.PlayPlayerHit(transform.position);
        if (UIManager.Instance != null)
            UIManager.Instance.UpdateHealth(currentHealth);
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        GameOverManager.Instance.ShowGameOver();
        // We'll hook up game over screen later
        gameObject.SetActive(false);
    }
}