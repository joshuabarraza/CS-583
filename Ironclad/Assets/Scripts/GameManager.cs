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
        // Singleton pattern - only one GameManager ever exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists between scenes
        }
        else
        {
            Destroy(gameObject); // destroy duplicate if one already exists
        }
    }

    // Call this from any script to add credits
    public void AddCredits(int amount)
    {
        shellCredits += amount;
        Debug.Log("Shell Credits: " + shellCredits);
    }

    // Call this from any script to damage the player
    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        Debug.Log("Player Health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
            // We'll hook up the game over screen later
        }
    }
}