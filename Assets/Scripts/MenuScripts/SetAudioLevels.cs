using UnityEngine;
using UnityEngine.Audio;

public class SetAudioLevels : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void SetMusicLevel(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
    }

    public void SetSfxLevel(float sfxLevel)
    {
        mainMixer.SetFloat("sfxVol", sfxLevel);
    }
}
