using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        // use whatever maxHealth GameManager has (could be upgraded)
        currentHealth = GameManager.Instance.maxHealth;
        UIManager.Instance.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        SoundManager.Instance.PlayPlayerHit(transform.position);
        UIManager.Instance.UpdateHealth(currentHealth);
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Game Over");
        GameOverManager.Instance.ShowGameOver();
        gameObject.SetActive(false);
    }
}
