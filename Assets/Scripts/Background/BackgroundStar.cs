using UnityEngine;

public class BackgroundStar : MonoBehaviour
{
    public float speed = -0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //get the current position of the star
        Vector2 position = transform.position;

        //Compute the star's new position
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        //Update the star's position
        transform.position = position;

        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x)
        {
            transform.position = new Vector3(max.x, Random.Range(min.y, max.y));
        }
    }
}
