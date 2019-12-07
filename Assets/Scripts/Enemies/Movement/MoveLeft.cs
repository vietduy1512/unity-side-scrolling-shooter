using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float xStop = 1f;

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x < xStop)
            gameObject.GetComponent<MoveLeft>().enabled = false;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        pos -= transform.rotation * velocity;

        transform.position = pos;
    }
}