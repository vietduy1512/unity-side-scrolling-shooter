using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;
    public int MaxStars;

    public float speed = 0.4f;

    void Start()
    {

        //bottom-left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(Star);
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            star.GetComponent<BackgroundStar>().speed = -(speed * Random.value + 0.1f);
            star.transform.parent = transform;
        }
    }

    void Update()
    {

    }
}
