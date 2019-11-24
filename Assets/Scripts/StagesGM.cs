using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StagesGM : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.

	public GameObject gameOverUI;
	public GameObject gamePlayUI;
	public GameObject winUI;

	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	private bool sceneEnding = false;

	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
		if(sceneEnding)
			// ... call the EndScene function.
			EndScene();
		if (Input.GetButtonDown ("Cancel")) {
			
			if (Time.timeScale == 0) {
				GetComponent<AudioSource> ().Play ();
			} else {
				GetComponent<AudioSource> ().Pause ();
			}
		}
	}


	void FadeToClear ()
	{
		// Fade-in audio
		if (GetComponent<AudioSource>().volume < 1)
			GetComponent<AudioSource>().volume += 1 * Time.deltaTime;
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack ()
	{
		// Fade-out audio
		if(GetComponent<AudioSource>().volume > 0)
			GetComponent<AudioSource>().volume -= 1 * Time.deltaTime;
		// Lerp the colour of the texture between itself and black.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}


	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if(GetComponent<GUITexture>().color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}
	}


	public void EndScene ()
	{
		// Make sure the texture is enabled.
		GetComponent<GUITexture>().enabled = true;
		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if(GetComponent<GUITexture>().color.a >= 0.95f)
			// ... reload the level.
			SceneManager.LoadScene(0);
	}

	public void ChangeToStagesSelection()
	{
		gameOverUI.SetActive (false);
		gamePlayUI.SetActive (false);
		winUI.SetActive (false);
		sceneEnding = true;
	}
}
