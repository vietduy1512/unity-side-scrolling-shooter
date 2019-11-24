using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;

	public bool isMoving = true;

	float shipBoundaryRadius = 0.5f;

	void Update () {

		// NO MOVING HERE
		if(!isMoving) return;

		Vector3 pos = transform.position;
		Vector3 velocity;

		// SHIFT button to slow down
		if (Input.GetButton ("Slow")) {
			velocity = new Vector3 (Input.GetAxis("Horizontal") * maxSpeed / 4 * Time.deltaTime,Input.GetAxis("Vertical") * maxSpeed / 4 * Time.deltaTime, 0);
		} else {
			velocity = new Vector3 (Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime,Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
		}

		pos += transform.rotation * velocity;

		// RESTRICT the player to the camera's boundaries!

		// First to vertical, because it's simpler
		if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		// Now calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if(pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}
		// FINALLY
		transform.position = pos;
	}


}

/*// ROTATE the ship.

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// Grab the Z euler angle
		float z = rot.eulerAngles.z;

		// Change the Z angle based on input
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

		// Recreate the quaternion
		rot = Quaternion.Euler( 0, 0, z );

		// Feed the quaternion into our rotation
		transform.rotation = rot;

		// MOVE the ship.
		Vector3 pos = transform.position;
		 
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

		pos += rot * velocity;*/
