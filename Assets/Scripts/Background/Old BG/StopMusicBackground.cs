using UnityEngine;

public class StopMusicBackground : MonoBehaviour
{
    private PlayMusic playMusic;

    public AnimationClip fadeColorAnimationClip;

    void Start()
    {

        playMusic = GetComponent<PlayMusic>();
    }

    [System.Obsolete]
    void Update()
    {

        if (Application.loadedLevel > 1)
        {

            playMusic.FadeDown(fadeColorAnimationClip.length);

            Invoke("Deactive", 1);
        }
    }

    void Deactive()
    {
        playMusic.FadeUp(0.01f);

        gameObject.SetActive(false);
    }
}
