using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    public AudioClip titleMusic;
    public AudioClip mainMusic;
    public AudioMixerSnapshot volumeDown;
    public AudioMixerSnapshot volumeUp;


    private AudioSource musicSource;
    private float resetTime = .01f;


    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }


    public void PlayLevelMusic()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                musicSource.clip = titleMusic;
                break;
            case 1:
                musicSource.clip = mainMusic;
                break;
        }
        FadeUp(resetTime);
        musicSource.Play();
    }

    public void PlaySelectedMusic(int musicChoice)
    {

        switch (musicChoice)
        {
            case 0:
                musicSource.clip = titleMusic;
                break;
            case 1:
                musicSource.clip = mainMusic;
                break;
        }
        musicSource.Play();
    }

    public void FadeUp(float fadeTime)
    {
        volumeUp.TransitionTo(fadeTime);
    }

    public void FadeDown(float fadeTime)
    {
        volumeDown.TransitionTo(fadeTime);
    }
}
