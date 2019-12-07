using UnityEngine;

public class ThreeShot : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;

    public float requirePosition = 5f;

    public float fireDelay = 0.50f;

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

            // The 30' degrees bullets
            Quaternion rot = Quaternion.identity;

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            // 2nd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 20);
            Instantiate(bulletPrefab, transform.position + offset, rot);
            // 3rd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -20);
            Instantiate(bulletPrefab, transform.position + offset, rot);
        }
    }
}