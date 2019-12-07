using UnityEngine;

public class MoveRightUI : MonoBehaviour
{
    public float speed = 5f;
    public float xStop = 1f;
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 condition = Camera.main.ScreenToWorldPoint(pos);
        if (condition.x > xStop)
            gameObject.GetComponent<MoveRightUI>().enabled = false;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
