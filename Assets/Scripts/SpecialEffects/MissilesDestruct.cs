using UnityEngine;

public class MissilesDestruct : MonoBehaviour
{
    public GameObject Explosion;

    public float timer = 1f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PlayExplosion();
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //set the position of the explosion
        explosion.transform.position = transform.position;
    }
}
