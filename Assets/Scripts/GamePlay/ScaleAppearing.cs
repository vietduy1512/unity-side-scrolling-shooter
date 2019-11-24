using UnityEngine;
using System.Collections;

public class ScaleAppearing : MonoBehaviour {

	public float scaleSpeed = 1f;

	public float zoomDelay = 0.5f;

	float delay, maxScale;
	// Use this for initialization
	void Start () {
		
		delay = zoomDelay;
		scaleSpeed *= 0.1f;
		maxScale = transform.localScale.x;
		transform.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		delay -= Time.deltaTime;

		if (transform.localScale.x >= maxScale) {
			
			return;
		} else if (delay <= 0) {
			
			delay = zoomDelay;
			transform.localScale += new Vector3 (scaleSpeed, scaleSpeed, scaleSpeed);
		}
	}
}
