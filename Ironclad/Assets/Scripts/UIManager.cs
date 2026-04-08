using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public Slider healthBar;

    void Awake()
    {
        // Always use the UIManager in the current scene
        Instance = this;
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            UpdateScore(GameManager.Instance.shellCredits);
            UpdateHealth(GameManager.Instance.maxHealth);
        }
    }

    public void UpdateScore(int credits)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + credits;
        else
            Debug.LogWarning("scoreText is null!");
    }

    public void UpdateHealth(int health)
    {
        if (healthBar != null)
        {
            // keep the slider max in sync so the bar scales correctly after armor upgrades
            healthBar.maxValue = GameManager.Instance.maxHealth;
            healthBar.value = health;
        }
        else
            Debug.LogWarning("healthBar is null!");
    }
}