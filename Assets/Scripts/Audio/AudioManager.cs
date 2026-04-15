using UnityEngine;

public enum SFXType
{
    SpringJump,
    HopSteps
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("SFX")]
    public AudioClip SpringJumpSFX;
    public AudioClip[] HopStepsSFX;

    [Header("Music")]
    public AudioClip backgroundMusic;

    private AudioSource sfxSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // SFX
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Music
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlaySFX(SFXType type, float volume = 1f)
    {
        AudioClip clip = null;

        switch (type)
        {
            case SFXType.SpringJump:
                clip = SpringJumpSFX;
                break;

            case SFXType.HopSteps:
                if (HopStepsSFX.Length > 0)
                    clip = HopStepsSFX[Random.Range(0, HopStepsSFX.Length)];
                break;
        }

        if (clip != null)
            sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic(AudioClip clip, float volume = 0.25f)
    {
        if (clip == null) return;
        if (musicSource.isPlaying && musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.loop = true;
        musicSource.Play();
    }
}