using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float startSpawningTime = 0f;

    [SerializeField] float timeBetweenSpawns = 0.5f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfEnemies = 5;

    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() => enemyPrefab;

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;

    }

    public float GetStartSpawningTime() => startSpawningTime;

    public float GetTimeBetweenSpawns() => timeBetweenSpawns;

    public float GetSpawnRandomFactor() => spawnRandomFactor;

    public int GetNumberOfEnemies() => numberOfEnemies;

    public float GetMoveSpeed() => moveSpeed;
}
