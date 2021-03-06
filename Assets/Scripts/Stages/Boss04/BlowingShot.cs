using UnityEngine;

public class BlowingShot : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float requirePosition = 5f;

    [SerializeField] float fireDelay = 0.50f;

    [SerializeField] int angle = 15;

    float cooldownTimer = 0;

    Transform player;

    int j = 4;

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

            CreateBullet();
        }
    }

    void CreateBullet()
    {
        Vector3 offset = transform.rotation * bulletOffset;

        j++;
        // The 30' degrees bullets
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = transform.eulerAngles + new Vector3(0, 180, j * -10 + angle);

        // Creat Bullets
        Instantiate(bulletPrefab, transform.position + offset, rot);

        if (j == 15)
            j = 5;
    }
}