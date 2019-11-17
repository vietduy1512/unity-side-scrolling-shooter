using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;

    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnEnemies(currentWave));
    }

    private IEnumerator SpawnEnemies(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            Instantiate(waveConfig.GetEnemyPrefab(),
               waveConfig.GetWaypoints()[0].transform.position,
               Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
