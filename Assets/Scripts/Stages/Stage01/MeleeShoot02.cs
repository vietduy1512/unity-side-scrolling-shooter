using UnityEngine;

public class MeleeShoot02 : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0.5f, 0, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float requirePosition = 25f;

    [SerializeField] float fireDelay = 0f;

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

            Quaternion rot = Quaternion.identity;

            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90);
            Instantiate(bulletPrefab, transform.position - offset, rot);

            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -90);
            Instantiate(bulletPrefab, transform.position + offset, rot);
        }
    }
}
