using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class StopMusicBackground : MonoBehaviour {

	private PlayMusic playMusic;

	public AnimationClip fadeColorAnimationClip;

	// Use this for initialization
	void Start () {
		
		playMusic = GetComponent<PlayMusic> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Application.loadedLevel > 1) {
			
			playMusic.FadeDown (fadeColorAnimationClip.length);

			Invoke ("Deactive", 1);
		}
	}

	void Deactive()
	{
		playMusic.FadeUp (0.01f);

		gameObject.SetActive (false);
	}
}
