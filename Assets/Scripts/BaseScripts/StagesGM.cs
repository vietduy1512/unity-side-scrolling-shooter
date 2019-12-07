using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesGM : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1.5f;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject winUI;

    private bool sceneStarting = true;
    private bool sceneEnding = false;

    void Awake()
    {
    }


    void Update()
    {
        if (sceneStarting)
            StartScene();
        if (sceneEnding)
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
        if (GetComponent<AudioSource>().volume < 1)
            GetComponent<AudioSource>().volume += 1 * Time.deltaTime;
    }


    void FadeToBlack()
    {
        if (GetComponent<AudioSource>().volume > 0)
            GetComponent<AudioSource>().volume -= 1 * Time.deltaTime;
    }

    void StartScene()
    {
        FadeToClear();
    }


    public void EndScene()
    {
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
