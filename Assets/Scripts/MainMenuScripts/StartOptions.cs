using UnityEngine;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour
{
    public int sceneToStart = 1;
    public bool changeScenes;
    public bool changeMusicOnStart;


    [HideInInspector] public bool inMainMenu = true;
    public Animator animColorFade;
    [HideInInspector] public Animator animMenuAlpha;
    public AnimationClip fadeColorAnimationClip;
    [HideInInspector] public AnimationClip fadeAlphaAnimationClip;

    private PlayMusic playMusic;
    private ShowPanels showPanels;

    void Awake()
    {
        showPanels = GetComponent<ShowPanels>();

        playMusic = GetComponent<PlayMusic>();
    }

    public void StartButtonClicked()
    {
        if (changeMusicOnStart)
        {
            playMusic.FadeDown(fadeColorAnimationClip.length);
        }

        if (changeScenes)
        {
            Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);

            animColorFade.SetTrigger("fade");
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += PlayMusicOnSceneLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayMusicOnSceneLoad;
    }

    void PlayMusicOnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (changeMusicOnStart)
        {
            playMusic.PlayLevelMusic();
        }
    }

    public void LoadDelayed()
    {
        inMainMenu = false;

        showPanels.HideMenu();

        SceneManager.LoadScene(sceneToStart);

        Invoke("ResetScript", fadeColorAnimationClip.length * .5f);
    }

    public void HideDelayed()
    {
        showPanels.HideMenu();
    }

    public void StartStages(int level)
    {
        sceneToStart = level + 1;
        Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);

        animColorFade.SetTrigger("fade");
    }

    void ResetScript()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
