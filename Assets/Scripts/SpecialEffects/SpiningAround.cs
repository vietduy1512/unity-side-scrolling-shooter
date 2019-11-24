using UnityEngine;
using System.Collections;

public class SpiningAround : MonoBehaviour {

	public float rotSpeed = 0.1f;

	// Update is called once per frame
	void Update () {
		
		transform.Rotate (0, 0, rotSpeed);
	}
}
