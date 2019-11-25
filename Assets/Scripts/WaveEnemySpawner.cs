using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    [SerializeField] int startingWave = 0;

    [SerializeField] bool isLoop = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        }
        while (isLoop);
    }

    private IEnumerator SpawnWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnEnemies(currentWave));
        }
    }

    private IEnumerator SpawnEnemies(WaveConfig waveConfig)
    {
        yield return new WaitForSeconds(waveConfig.GetStartSpawningTime());
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var enemy = Instantiate(waveConfig.GetEnemyPrefab(),
               waveConfig.GetWaypoints()[0].transform.position,
               Quaternion.identity);
            
            enemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
