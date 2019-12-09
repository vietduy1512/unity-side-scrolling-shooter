using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject explosion = null;

        if (col.gameObject.GetComponent<PlayerDamageHandle>() != null)
        {

            explosion = (GameObject)Instantiate(col.gameObject.GetComponent<PlayerDamageHandle>().Explosion);
            explosion.transform.position = col.transform.position;

            Destroy(col.gameObject.GetComponent<PlayerDamageHandle>().Health);

        }
        else
        {

            explosion = (GameObject)Instantiate(col.gameObject.GetComponent<DamageHandler>().Explosion);
            explosion.transform.position = col.transform.position;

            Destroy(col.gameObject.GetComponent<DamageHandler>().Health);
        }
        Destroy(col.gameObject);
    }
}
