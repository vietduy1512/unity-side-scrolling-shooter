using UnityEngine;

public class BackgroundStar : MonoBehaviour
{
    public float speed = -0.1f;

    void Start()
    {

    }

    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;

        //the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x)
        {
            transform.position = new Vector3(max.x, Random.Range(min.y, max.y));
        }
    }
}
