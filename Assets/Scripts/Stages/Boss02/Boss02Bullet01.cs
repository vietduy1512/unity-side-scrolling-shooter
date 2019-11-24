using UnityEngine;
using System.Collections;

public class Boss02Bullet01 : MonoBehaviour {

	int i = 0;
	GameObject previousGO;
	public GameObject[] GO = new GameObject[50];

	public int maxFrames = 9;

	float animated = 0.0828f;	// SPECIAL NUMBER
	float timer;

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer <= 0) {

			for (; i <= maxFrames; i++) {

				if (i == maxFrames) {

					i = 0;
					return;
				}

				if (i == 0) {
					if (previousGO != null)
						previousGO.GetComponent<PolygonCollider2D> ().enabled = false;
				}
				else
					GO [i].GetComponent<PolygonCollider2D> ().enabled = true;
				
				previousGO = GO [i];
				timer = animated;


			}
				
		}
	}
}
