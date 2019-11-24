using UnityEngine;
using System.Collections;

public class BossShoot02 : MonoBehaviour {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//bottom-left of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//top-right of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject bullet = (GameObject)Instantiate(bulletPrefab);

		//set the position of the bullet (random x and random y)
		bullet.transform.position = new Vector2(max.x - 0.5f, Random.Range(min.y, max.y));

		//make the bullet a child of the bulletPrefabGenerator
		bullet.transform.parent = transform;

	}
}
