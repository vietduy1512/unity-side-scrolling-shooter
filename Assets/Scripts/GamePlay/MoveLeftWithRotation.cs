using UnityEngine;

public class MoveLeftWithRotation : MonoBehaviour
{
    public float speed = 5f;            //Speed of the scrolling
    public float xStop = 1f;            //Stop position (0 to 500)

    void Update()
    {
        Vector3 pos = transform.position;
        // If true == Stop here
        if (pos.x > xStop)
            gameObject.GetComponent<MoveLeftWithRotation>().enabled = false;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        pos -= transform.rotation * velocity;

        transform.position = pos;
    }
}