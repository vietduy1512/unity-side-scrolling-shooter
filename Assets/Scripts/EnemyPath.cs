using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointsIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointsIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointsIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position,
                                                    targetPosition,
                                                    moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
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
