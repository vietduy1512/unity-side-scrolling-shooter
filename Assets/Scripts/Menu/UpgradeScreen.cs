using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgradeScreem()
    {
        Time.timeScale = 0;
        StagesGM.PauseAudio();
        gameObject.SetActive(true);
    }

    public void CloseUpgradeScreem()
    {
        Time.timeScale = 1;
        StagesGM.ResumeAudio();
        gameObject.SetActive(false);
    }
}
