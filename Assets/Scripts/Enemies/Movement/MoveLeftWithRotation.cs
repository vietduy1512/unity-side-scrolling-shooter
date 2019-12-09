using UnityEngine;

public class MoveLeftWithRotation : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float xStop = 1f;

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