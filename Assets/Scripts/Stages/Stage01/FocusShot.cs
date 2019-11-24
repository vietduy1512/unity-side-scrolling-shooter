using UnityEngine;
using System.Collections;

public class FocusShot : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	public GameObject bulletPrefab;

	public float requirePosition = 5f;

	public float fireDelay = 0.50f;

	float cooldownTimer = 0;

	Transform player;


	void Start() {

	}

	// Update is called once per frame
	void Update () {

		if(player == null) {
			// Find the player's ship!
			GameObject go = GameObject.FindWithTag ("Player");

			if(go != null) {
				player = go.transform;
			}
		}

		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < requirePosition)
		{
			// SHOOT!
			//Debug.Log ("Enemy Pew!");
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			// Creat Bullets
			Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			// 2nd
			offset = transform.rotation * new Vector3 (-0.3f, 0, 0);
			Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			// 3rd
			offset = transform.rotation * new Vector3 (0.3f, 0, 0);
			Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
		}
	}
}