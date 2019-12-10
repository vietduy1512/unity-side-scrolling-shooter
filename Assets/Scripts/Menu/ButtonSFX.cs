using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource buttonSFX;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayClickSFX()
    {
        buttonSFX.PlayOneShot(buttonSFX.clip);
    }
}
