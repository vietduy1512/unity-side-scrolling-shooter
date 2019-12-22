using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int sceneToStart = 1;

    public GameObject optionsScreen;

    public GameObject loadingScreen, loadingIcon;

    public Text loadingText;

    StartOptions startOptions;

    void Start()
    {
        optionsScreen.GetComponent<OptionsMenu>().SetupOptions();
        startOptions = transform.GetComponent<StartOptions>();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        //StartCoroutine(LoadStart());
        startOptions.StartFirstStage();
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //public IEnumerator LoadStart()
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(firstLevel);

    //    if (!loadingScreen)
    //    {
    //        asyncLoad.allowSceneActivation = true;
    //        Time.timeScale = 1f;
    //        yield return null;
    //        yield break;
    //    }

    //    loadingScreen.SetActive(true);

    //    asyncLoad.allowSceneActivation = false;

    //    while (!asyncLoad.isDone)
    //    {
    //        if (asyncLoad.progress >= .9f)
    //        {
    //            loadingText.text = "Press any key to continue";
    //            loadingIcon.SetActive(false);

    //            if (Input.anyKeyDown)
    //            {
    //                asyncLoad.allowSceneActivation = true;
    //                Time.timeScale = 1f;
    //            }
    //        }

    //        yield return null;
    //    }
    //}
}
