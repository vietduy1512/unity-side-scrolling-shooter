using UnityEngine;

public class ActiveIntroBG : MonoBehaviour
{
    public float speed = 0.1f;

    public float timer = 5f;

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GetComponent<ActiveIntroBG>().enabled = false;
            GetComponent<SpiningAround>().enabled = true;
        }

        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y + speed * Time.deltaTime);

        transform.position = pos;
    }
}
