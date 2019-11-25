using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject appearPrefab;

    [SerializeField] float spawnDistance = 12f;

    [SerializeField] float nextEnemy = 5; //Time to respawn Enemies
    [SerializeField] float beginEnemiesSpawn = 1; //Enemy in the begining

    [SerializeField] int enemiesInOneWave = 2;

    [SerializeField] int maxWaves = 4; //Max enemies

    GameObject[] Appearance = new GameObject[50];
    int num;
    bool notAppearing = true;
    Vector3[] offset = new Vector3[50];

    //Init
    void Start()
    {
        num = maxWaves;
        beginEnemiesSpawn += 2;
        nextEnemy += 2;
    }

    // Update is called once per frame
    void Update()
    {
        beginEnemiesSpawn -= Time.deltaTime;

        EnemyAppearance();
    }

    void EnemyAppearance()
    {
        if (beginEnemiesSpawn <= 0 && num > 0 && !notAppearing)
        {
            num--;
            beginEnemiesSpawn = nextEnemy;

            for (int j = 0; j < enemiesInOneWave; j++)
            {
                Instantiate(enemyPrefab, transform.position + offset[j], Quaternion.Euler(0, 0, 90));
                Destroy(Appearance[j]);
            }

            notAppearing = true;
        }
        else if (beginEnemiesSpawn <= 2 && num > 0 && notAppearing)
        {
            for (int j = 0; j < enemiesInOneWave; j++)
            {
                RandomPosition(j);
                notAppearing = false;
                Appearance[j] = (GameObject)Instantiate(appearPrefab, transform.position + offset[j], Quaternion.identity);
                Appearance[j].transform.localScale = new Vector3(0, 0, 0);
            }
        }
        else if (beginEnemiesSpawn <= 2 && num > 0 && !notAppearing)
        {
            for (int j = 0; j < enemiesInOneWave; j++)
            {
                if (Appearance[j].transform.localScale == new Vector3(1f, 1f, 1f))
                {
                    return;
                }
                Appearance[j].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        else if (num <= 0) //After the last wave, SELF DESTRUCT
        {
            Destroy(gameObject);
        }
    }

    void RandomPosition(int j)
    {
        offset[j] = Random.onUnitSphere;
        offset[j] = offset[j].normalized * spawnDistance;

        offset[j].x = Mathf.Abs(offset[j].x);
        offset[j].y /= 2;
        offset[j].z = 0;
    }
}