using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("References")]
    public GameObject levelCompletePanel;
    public GameObject hudPanel;
    public TextMeshProUGUI finalScoreText;

    private int enemyCount;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        levelCompletePanel.SetActive(false);
        enemyCount = FindObjectsOfType<EnemyHealth>().Length;
    }

    public void EnemyDefeated()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            ShowLevelComplete();
        }
    }

    void ShowLevelComplete()
    {
        // Hide HUD
        if (hudPanel != null)
            hudPanel.SetActive(false);

        // Show final score
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + GameManager.Instance.shellCredits + " SC";

        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro");
    }
}