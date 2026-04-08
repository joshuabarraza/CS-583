using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    [Header("References")]
    public GameObject pausePanel;
    public GameObject hudPanel;

    [Header("Audio")]
    public AudioClip pauseClip;
    public AudioClip resumeClip;
    public AudioClip buttonClickClip;
    private AudioSource audioSource;

    private bool isPaused = false;

    void Awake()
    {
        Instance = this;
        Debug.Log("PauseManager Awake - instance set on: " + gameObject.name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        Debug.Log("TogglePause called, isPaused: " + isPaused);
        isPaused = !isPaused;

        if (isPaused)
        {
            PlaySound(pauseClip);
            pausePanel.SetActive(true);
            if (hudPanel != null) hudPanel.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            PlaySound(resumeClip);
            pausePanel.SetActive(false);
            if (hudPanel != null) hudPanel.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        PlaySound(resumeClip);
        isPaused = false;
        pausePanel.SetActive(false);
        if (hudPanel != null) hudPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        PlaySound(buttonClickClip);
        GameManager.Instance.shellCredits = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }
}