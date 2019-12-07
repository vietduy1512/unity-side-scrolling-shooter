using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 5f;
    public float xStop = 1f;

    void Update()
    {
        Vector3 pos = transform.position;
        // If true == Stop here
        if (pos.x > xStop)
            gameObject.GetComponent<MoveRight>().enabled = false;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
