using UnityEngine;

public class Pause : MonoBehaviour
{
    private ShowPanels showPanels;
    private bool isPaused;
    private StartOptions startScript;

    void Awake()
    {
        showPanels = GetComponent<ShowPanels>();
        startScript = GetComponent<StartOptions>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Cancel") && !isPaused && !startScript.inMainMenu)
        {
            DoPause();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused && !startScript.inMainMenu)
        {
            UnPause();
        }

    }


    public void DoPause()
    {
        isPaused = true;
        Time.timeScale = 0;
        showPanels.ShowPausePanel();
    }


    public void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1;
        showPanels.HidePausePanel();
    }
}
