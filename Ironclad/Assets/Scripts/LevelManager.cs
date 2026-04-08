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

    [Header("Audio")]
    public AudioClip buttonClickClip;
    private AudioSource audioSource;

    private int enemyCount;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        levelCompletePanel.SetActive(false);
        enemyCount = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
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
        if (hudPanel != null)
            hudPanel.SetActive(false);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + GameManager.Instance.shellCredits;

        levelCompletePanel.SetActive(true);
    
        if (UpgradeManager.Instance != null)
            UpgradeManager.Instance.ShowUpgrades();

        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        if (buttonClickClip != null) audioSource.PlayOneShot(buttonClickClip);
        Time.timeScale = 1f;
        UpgradeManager.Instance.ResetUpgradeButtons();
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Tutorial")
            SceneManager.LoadScene("Level1");
        else if (currentScene == "Level1")
            SceneManager.LoadScene("Level2");
    }

    public void RetryLevel()
    {
        if (buttonClickClip != null) audioSource.PlayOneShot(buttonClickClip);
        Time.timeScale = 1f;
        if (UpgradeManager.Instance != null)
            UpgradeManager.Instance.ResetUpgradeButtons();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        if (buttonClickClip != null) audioSource.PlayOneShot(buttonClickClip);
        GameManager.Instance.shellCredits = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}