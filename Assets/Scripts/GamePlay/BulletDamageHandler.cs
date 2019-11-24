using UnityEngine;
using System.Collections;

public class BulletDamageHandler : MonoBehaviour {

	public GameObject Explosion;

	public int health = 1;

	void OnTriggerEnter2D() {
		health--;
	}

	void Update()
	{
		if (health <= 0)
		{
			PlayExplosion();
			Die();
		}

	}

	void Die() {
		Destroy(gameObject);
	}

	//set explosion
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);

		//set the position of the explosion
		explosion.transform.position = transform.position;
	}

}
