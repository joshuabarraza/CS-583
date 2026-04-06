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
            UpdateHealth(GameManager.Instance.playerHealth);
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
            healthBar.value = health;
        else
            Debug.LogWarning("healthBar is null!");
    }
}