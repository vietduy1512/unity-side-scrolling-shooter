using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float requirePosition = 5f;

    [SerializeField] float fireDelay = 0.50f;

    float cooldownTimer = 0;

    Transform player;

    void Start()
    {

    }

    void Update()
    {

        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < requirePosition)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
