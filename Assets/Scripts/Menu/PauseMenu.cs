using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsScreen, pauseScreen;

    public string mainMenuScene;

    private bool isPaused = false;

    public GameObject loadingScreen, loadingIcon;

    public Text loadingText;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Resume();
        }
    }

    public void Resume()
    {
        if (optionsScreen.activeSelf)
        {
            return;
        }

        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            StagesGM.PauseAudio();
        }
        else
        {
            Time.timeScale = 1f;
            StagesGM.ResumeAudio();
        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        // SceneManager.LoadScene(mainMenuScene);

        StartCoroutine(LoadMain());
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) {
            if (asyncLoad.progress >= .9f) {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown) {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }
}
