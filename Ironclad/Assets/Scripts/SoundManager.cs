using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Clips")]
    public AudioClip crateHitClip;
    [Range(0f, 1f)] public float crateHitVolume = 1f;

    public AudioClip wallHitClip;
    [Range(0f, 1f)] public float wallHitVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play a sound at a specific position in the scene
    public void PlaySound(AudioClip clip, Vector3 position, float volume = 1f)
    {
    if (clip == null) return;

    GameObject tempAudio = new GameObject("TempAudio");
    tempAudio.transform.position = position;
    AudioSource source = tempAudio.AddComponent<AudioSource>();
    source.clip = clip;
    source.spatialBlend = 0f;
    source.volume = volume;
    source.Play();

    Destroy(tempAudio, clip.length);
    }
}