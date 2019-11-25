using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    WaveConfig waveConfig;

    List<Transform> waypoints;
    
    int waypointsIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointsIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointsIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position,
                                                    targetPosition,
                                                    waveConfig.GetMoveSpeed() * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
