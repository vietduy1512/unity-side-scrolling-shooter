using UnityEngine;

public class BulletDamageHandler : MonoBehaviour
{
    [SerializeField] GameObject Explosion;

    [SerializeField] int health = 1;

    void OnTriggerEnter2D()
    {
        health--;
    }

    void Update()
    {
        if (health <= 0)
        {
            PlayExplosion();
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}
