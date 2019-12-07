using UnityEngine;

public class BlowingBullet : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;

    public float requirePosition = 10f;

    public float cooldownTimer = 4f;

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

            CreateBullet();
            Destroy(gameObject);
        }
    }

    void CreateBullet()
    {
        // The 30' degrees bullets
        Quaternion rot = Quaternion.identity;

        for (int i = 0; i < 8; i++)
        {

            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, i * 45);

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position, rot);
        }
    }
}