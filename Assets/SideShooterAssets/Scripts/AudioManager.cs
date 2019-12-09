using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    void Start()
    {
        if (PlayerPrefs.HasKey("masterVol")) {
            mixer.SetFloat("masterVol", PlayerPrefs.GetFloat("masterVol"));
        }

        if (PlayerPrefs.HasKey("musicVol")) {
            mixer.SetFloat("musicVol", PlayerPrefs.GetFloat("musicVol"));
        }

        if (PlayerPrefs.HasKey("sfxVol")) {
            mixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("sfxVol"));
        }
    }

    void Update()
    {
        
    }
}
