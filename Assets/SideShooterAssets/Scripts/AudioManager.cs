using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol")) {
            mixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }

        if (PlayerPrefs.HasKey("MusicVol")) {
            mixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }

        if (PlayerPrefs.HasKey("SFXVol")) {
            mixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
