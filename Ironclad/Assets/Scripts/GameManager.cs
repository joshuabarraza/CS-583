using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static instance accessible from any script
    public static GameManager Instance;

    [Header("Player Stats")]
    public int shellCredits = 0;
    public int playerHealth = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this from any script to add credits
    public void AddCredits(int amount)
    {
        shellCredits += amount;
        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScore(shellCredits);
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        UIManager.Instance.UpdateHealth(playerHealth);

        if (playerHealth <= 0) {
            Debug.Log("Game Over");
        }
    }
}