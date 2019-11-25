using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;
    public int MaxStars;

    public float speed = 0.4f;

    //Array of colors
    /*Color[] starColors = {
        new Color (0.5f, 0.5f, 1f), //blue
        new Color (0, 1f, 1f), //green
        new Color (1f, 1f, 0), //yellow
        new Color (1f, 0, 0), //red
    };*/

    // Use this for initialization
    void Start()
    {

        //bottom-left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Loop to create the stars
        for (int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(Star);

            //Set the star color
            //star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //set the position of the star (random x and random y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            star.GetComponent<BackgroundStar>().speed = -(speed * Random.value + 0.1f);

            //make the star a child of the StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
