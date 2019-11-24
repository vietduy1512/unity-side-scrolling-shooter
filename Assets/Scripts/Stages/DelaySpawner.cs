using UnityEngine;
using System.Collections;

public class DelaySpawner : MonoBehaviour {

	public float delay;

	// Use this for initialization
	void Start () {
		
		gameObject.SetActive (false);
		Invoke ("Spawn", delay);
	}

	void Spawn()
	{
		gameObject.SetActive (true);
	}
}
