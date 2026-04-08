using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    public int shellCredits = 0;
    public int playerHealth = 3;

    [Header("Upgrades")]
    public int bulletDamage = 1;
    public float bulletSpeed = 10f;
    public int maxHealth = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null); // must be root level for DontDestroyOnLoad to work
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCredits(int amount)
    {
        shellCredits += amount;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScore(shellCredits);
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateHealth(playerHealth);

        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}