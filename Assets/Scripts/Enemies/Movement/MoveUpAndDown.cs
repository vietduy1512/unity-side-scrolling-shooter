using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    [SerializeField] bool moveUp;

    [SerializeField] bool isScaleFollowGO = true;

    [SerializeField] float maxSpeed = 5f;

    [SerializeField] float yRange = 6f;

    void Start()
    {
        if (isScaleFollowGO)
        {
            yRange += transform.position.y;
        }
    }

    void Update()
    {

        if (moveUp)
        {
            transform.position += new Vector3(0, maxSpeed * Time.deltaTime, 0);
            if (transform.position.y > yRange)
                moveUp = false;
        }
        else
        {
            transform.position -= new Vector3(0, maxSpeed * Time.deltaTime, 0);
            if (transform.position.y < -yRange)
                moveUp = true;
        }
    }
}
