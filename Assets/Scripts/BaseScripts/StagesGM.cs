using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesGM : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.

    public GameObject gameOverUI;
    public GameObject gamePlayUI;
    public GameObject winUI;

    private bool sceneStarting = true;      // Whether or not the scene is still fading in.
    private bool sceneEnding = false;

    void Awake()
    {
    }


    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();
        if (sceneEnding)
            // ... call the EndScene function.
            EndScene();
        if (Input.GetButtonDown("Cancel"))
        {

            if (Time.timeScale == 0)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Pause();
            }
        }
    }


    void FadeToClear()
    {
        // Fade-in audio
        if (GetComponent<AudioSource>().volume < 1)
            GetComponent<AudioSource>().volume += 1 * Time.deltaTime;
    }


    void FadeToBlack()
    {
        // Fade-out audio
        if (GetComponent<AudioSource>().volume > 0)
            GetComponent<AudioSource>().volume -= 1 * Time.deltaTime;
    }

    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();
    }


    public void EndScene()
    {
        // Start fading towards black.
        FadeToBlack();
        SceneManager.LoadScene(0);
    }

    public void ChangeToStagesSelection()
    {
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(false);
        winUI.SetActive(false);
        sceneEnding = true;
    }
}
