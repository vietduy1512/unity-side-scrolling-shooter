using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StagesGM : MonoBehaviour
{
    public static bool isStartGame = false;

    public static int lastStage = 2;

    public static int playerLives = 2;

    public static bool stageCleared = false;

    [SerializeField] int stageNumber;
    [SerializeField] float fadeSpeed = 3f;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject curtainLayer;
    [SerializeField] GameObject winUI;

    private bool sceneStarting = true;
    private bool sceneEnding = false;

    Image layer;

    static AudioSource audio;

    void Awake()
    {
        layer = curtainLayer.GetComponent<Image>();
        curtainLayer.SetActive(true);
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isStartGame = true;
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
        if (sceneEnding)
        {
            EndScene();
        }
        //if (Input.GetButtonDown("Cancel"))
        //{

        //    if (Time.timeScale == 0)
        //    {
        //        GetComponent<AudioSource>().Play();
        //    }
        //    else
        //    {
        //        GetComponent<AudioSource>().Pause();
        //    }
        //}
    }

    void FadeToClear()
    {
        if (GetComponent<AudioSource>().volume < 1)
        {
            GetComponent<AudioSource>().volume += 1 * Time.deltaTime;
        }
        layer.color = Color.Lerp(layer.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        if (GetComponent<AudioSource>().volume > 0)
        {
            GetComponent<AudioSource>().volume -= 1 * Time.deltaTime;
        }
        layer.color = Color.Lerp(layer.color, Color.black, fadeSpeed * 2 * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();
        if (layer.color.a <= 0.01f)
        {
            layer.color = Color.clear;
            sceneStarting = false;
        }
    }


    public void EndScene()
    {
        FadeToBlack();
        if(layer.color.a >= 0.95f)
        {
            if (stageNumber == lastStage)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene("Stage" + (stageNumber + 1));
            }
        }
    }

    public void ChangeToStagesSelection()
    {
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(false);
        winUI.SetActive(false);
        sceneStarting = false;
        sceneEnding = true;
    }

    public static void PauseAudio()
    {
        audio.Pause();
    }

    public static void ResumeAudio()
    {
        audio.Play();
    }
}
