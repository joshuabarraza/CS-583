using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        SoundManager.Instance.PlayEnemyHit(transform.position);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddCredits(50);
        if (LevelManager.Instance != null)
            LevelManager.Instance.EnemyDefeated();
        Destroy(gameObject);
    }
}