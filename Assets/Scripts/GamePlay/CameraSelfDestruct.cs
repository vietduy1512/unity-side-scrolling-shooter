using UnityEngine;
using System.Collections;

public class CameraSelfDestruct : MonoBehaviour {

	float shipBoundaryRadius = -0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		// First to vertical, because it's simpler
		if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			Destroy(gameObject);
		}
		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			Destroy(gameObject);
		}

		// Now calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if(pos.x+shipBoundaryRadius > widthOrtho) {
			Destroy(gameObject);
		}
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			Destroy(gameObject);
		}
	}
}
