using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject explosion = null;

		if (col.gameObject.GetComponent<PlayerDamageHandle> () != null) {
			
			explosion = (GameObject)Instantiate (col.gameObject.GetComponent<PlayerDamageHandle> ().Explosion);
			//set the position of the explosion
			explosion.transform.position = col.transform.position;

			Destroy (col.gameObject.GetComponent<PlayerDamageHandle> ().Health);

		} else {
			
			explosion = (GameObject)Instantiate (col.gameObject.GetComponent<DamageHandler> ().Explosion);
			//set the position of the explosion
			explosion.transform.position = col.transform.position;

			Destroy (col.gameObject.GetComponent<DamageHandler> ().Health);
		}



		Destroy(col.gameObject);
	}
}
