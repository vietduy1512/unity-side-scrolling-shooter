using UnityEngine;
using System.Collections;

public class Auto07EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject appearPrefab;
	GameObject Appearance;

	public float nextEnemy = 5; //Time to respawn Enemies
	public float beginEnemiesSpawn = 1; //Enemy in the begining

	bool notAppearing = true;

	//Init
	void Start()
	{
		beginEnemiesSpawn += 2;
		nextEnemy += 2;
	}

	// Update is called once per frame
	void Update () {
		beginEnemiesSpawn -= Time.deltaTime;

		EnemyAppearance ();
	}

	void EnemyAppearance()
	{
		if (beginEnemiesSpawn <= 0 && !notAppearing) {

			beginEnemiesSpawn = nextEnemy;

			// decrease cooldown -- Nah
			/*nextEnemy *= 0.9f;
			if(nextEnemy < 2)
				nextEnemy = 2;*/
			Instantiate (enemyPrefab, transform.position, Quaternion.identity);
			Destroy (Appearance);

			notAppearing = true;
		}
		else if (beginEnemiesSpawn <= 2 && notAppearing) {

			notAppearing = false;
			Appearance = (GameObject)Instantiate (appearPrefab, transform.position, Quaternion.identity);

			Appearance.transform.parent = transform;

			Appearance.transform.localScale = new Vector3 (0, 0, 0);
		} 
		else if (beginEnemiesSpawn <= 2 && !notAppearing) {

			if (Appearance.transform.localScale == new Vector3 (1f, 1f, 1f)) {
				return;
			}
			Appearance.transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
		}
	}
}
