using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickClip;

    public void PlayGame()
    {
        audioSource.PlayOneShot(buttonClickClip);
        Invoke("LoadGame", buttonClickClip.length);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}