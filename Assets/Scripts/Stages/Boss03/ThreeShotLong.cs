using UnityEngine;

public class ThreeShotLong : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float requirePosition = 5f;

    [SerializeField] float fireDelay = 0.50f;

    [SerializeField] float maxWaves = 7;

    [SerializeField] int angle = 15;

    float cooldownTimer = 0;

    Transform player;

    int j = 0;

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

            for (int i = 0; i < maxWaves; i++)
            {

                Invoke("CreateBullet", i * 0.2f);
                Invoke("CreateBullet", i * 0.3f);

            }
        }
    }

    void CreateBullet()
    {
        Vector3 offset = transform.rotation * bulletOffset;

        j++;
        // The 30' degrees bullets
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, j * 30 - angle);

        // Creat Bullets
        Instantiate(bulletPrefab, transform.position + offset, rot);
        // 2nd
        rot.eulerAngles += new Vector3(0, 0, 10);
        Instantiate(bulletPrefab, transform.position + offset, rot);
        // 3rd
        rot.eulerAngles += new Vector3(0, 0, 10);
        Instantiate(bulletPrefab, transform.position + offset, rot);

        // 2nd
        rot.eulerAngles += new Vector3(0, 0, -30);
        Instantiate(bulletPrefab, transform.position + offset, rot);
        // 3rd
        rot.eulerAngles += new Vector3(0, 0, -10);
        Instantiate(bulletPrefab, transform.position + offset, rot);

        if (j == 6)
            j = 0;
    }
}