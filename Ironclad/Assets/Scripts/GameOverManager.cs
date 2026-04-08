using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// shows the game over screen when player dies
public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    [Header("Audio")]
    public AudioClip buttonClickClip;
    private AudioSource audioSource;

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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + GameManager.Instance.shellCredits;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        if (buttonClickClip != null) audioSource.PlayOneShot(buttonClickClip);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        if (buttonClickClip != null) audioSource.PlayOneShot(buttonClickClip);
        Time.timeScale = 1f;
        GameManager.Instance.shellCredits = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
