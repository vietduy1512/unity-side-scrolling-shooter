using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public bool moveUp;

    public bool isScaleFollowGO = true;

    public float maxSpeed = 5f;

    public float yRange = 6f;

    // Use this for initialization
    void Start()
    {
        if (isScaleFollowGO)
        {
            yRange += transform.position.y;
        }
    }

    // Update is called once per frame
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
