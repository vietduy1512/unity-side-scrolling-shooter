using UnityEngine;

public class BossShoot02 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    void Start()
    {

    }

    void Update()
    {
        //bottom-left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject bullet = (GameObject)Instantiate(bulletPrefab);

        bullet.transform.position = new Vector2(max.x - 0.5f, Random.Range(min.y, max.y));

        bullet.transform.parent = transform;

    }
}
