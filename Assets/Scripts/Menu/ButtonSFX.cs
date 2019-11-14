using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource buttonSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSFX()
    {
        buttonSFX.PlayOneShot(buttonSFX.clip);
    }
}
