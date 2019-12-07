using UnityEngine;

public class Auto07EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject appearPrefab;
    GameObject Appearance;

    [SerializeField] float nextEnemy = 5;
    [SerializeField] float beginEnemiesSpawn = 1;

    bool notAppearing = true;

    void Start()
    {
        beginEnemiesSpawn += 2;
        nextEnemy += 2;
    }

    void Update()
    {
        beginEnemiesSpawn -= Time.deltaTime;

        EnemyAppearance();
    }

    void EnemyAppearance()
    {
        if (beginEnemiesSpawn <= 0 && !notAppearing)
        {

            beginEnemiesSpawn = nextEnemy;

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(Appearance);

            notAppearing = true;
        }
        else if (beginEnemiesSpawn <= 2 && notAppearing)
        {

            notAppearing = false;
            Appearance = (GameObject)Instantiate(appearPrefab, transform.position, Quaternion.identity);

            Appearance.transform.parent = transform;

            Appearance.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (beginEnemiesSpawn <= 2 && !notAppearing)
        {

            if (Appearance.transform.localScale == new Vector3(1f, 1f, 1f))
            {
                return;
            }
            Appearance.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
}
