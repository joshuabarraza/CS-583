using UnityEngine;

public class TankAudio : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource engineSource;  // looping engine sound
    public AudioSource shootSource;   // one-shot shoot sound

    [Header("Audio Clips")]
    public AudioClip idleClip;
    public AudioClip drivingClip;
    public AudioClip shootClip;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float engineVolume = 1f;
    [Range(0f, 1f)] public float shootVolume = 1f;

    private Rigidbody2D rb;
    private bool isDriving = false;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    engineSource.volume = engineVolume;
    engineSource.clip = idleClip;
    engineSource.loop = true;
    engineSource.Play();
    }

    void Update()
    {
        HandleEngineAudio();
    }

    void HandleEngineAudio()
    {
    float move = Input.GetAxis("Vertical");
    float turn = Input.GetAxis("Horizontal");
    bool moving = Mathf.Abs(move) > 0.1f || Mathf.Abs(turn) > 0.1f;

    if (moving && !isDriving)
    {
        isDriving = true;
        engineSource.clip = drivingClip;
        engineSource.loop = true;
        engineSource.volume = engineVolume;
        engineSource.Play();
    }
    else if (!moving && isDriving)
    {
        isDriving = false;
        engineSource.clip = idleClip;
        engineSource.loop = true;
        engineSource.volume = engineVolume;
        engineSource.Play();
    }
    }

    void PlayIdle()
    {
        if (!isDriving)
        {
            engineSource.volume = engineVolume;
            engineSource.clip = idleClip;
            engineSource.loop = true;
            engineSource.Play();
        }
    }

    public void PlayShoot()
    {
        shootSource.volume = shootVolume;
        shootSource.PlayOneShot(shootClip);
    }
}