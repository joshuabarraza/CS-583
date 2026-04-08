using UnityEngine;

public class TankAudio : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource engineSource;
    public AudioSource shootSource;

    [Header("Audio Clips")]
    public AudioClip idleClip;
    public AudioClip drivingClip;
    public AudioClip shootClip;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float engineVolume = 1f;
    [Range(0f, 1f)] public float shootVolume = 1f;

    private bool isDriving = false;

    void Start()
    {
        engineSource.volume = engineVolume;
        engineSource.clip = idleClip;
        engineSource.loop = true;
        engineSource.Play();
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        bool moving = Mathf.Abs(move) > 0.1f || Mathf.Abs(turn) > 0.1f;

        if (moving && !isDriving)
        {
            isDriving = true;
            engineSource.clip = drivingClip;
            engineSource.volume = engineVolume;
            engineSource.Play();
        }
        else if (!moving && isDriving)
        {
            isDriving = false;
            engineSource.clip = idleClip;
            engineSource.volume = engineVolume;
            engineSource.Play();
        }
    }

    public void PlayShoot()
    {
        shootSource.volume = shootVolume;
        shootSource.PlayOneShot(shootClip);
    }
}
