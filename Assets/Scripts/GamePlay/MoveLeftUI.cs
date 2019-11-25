using UnityEngine;

public class MoveLeftUI : MonoBehaviour
{
    public float speed = 5f;            //Speed of the scrolling
    public float xStop = 1f;            //Stop position (0 to 500)
    void Update()
    {
        Vector3 pos = transform.position;
        // If true == Stop here
        Vector3 condition = Camera.main.ScreenToWorldPoint(pos);
        if (condition.x < xStop)
            gameObject.GetComponent<MoveLeftUI>().enabled = false;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        pos -= transform.rotation * velocity;

        transform.position = pos;
    }
}
