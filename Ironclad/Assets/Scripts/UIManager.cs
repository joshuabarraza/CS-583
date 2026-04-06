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
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Initialize UI with current GameManager values on scene load
        if (GameManager.Instance != null)
        {
            UpdateScore(GameManager.Instance.shellCredits);
            UpdateHealth(GameManager.Instance.playerHealth);
        }
    }

    // Call this whenever credits change
    public void UpdateScore(int credits)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + credits;
    }

    // Call this whenever health changes
    public void UpdateHealth(int health)
    {
        if (healthBar != null)
            healthBar.value = health;
    }
}