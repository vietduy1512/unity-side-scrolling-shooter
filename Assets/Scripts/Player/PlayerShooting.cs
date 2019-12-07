using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] GameObject bulletPrefab2;

    [SerializeField] GameObject wallPrefab;

    [SerializeField] float rotSpeed = 180f;

    [SerializeField] float fireDelay = 0.25f;

    [SerializeField] float maxWalls = 2;

    float cooldownTimer = 0;

    [SerializeField] bool isShooting = true;

    int j = 0;

    void Start()
    {

    }

    void Update()
    {
        // PointGun();

        if (Input.GetButtonDown("Wall") && j < maxWalls)
        {
            Instantiate(wallPrefab, transform.position + transform.rotation * new Vector3(0, 1f, 0), transform.rotation);
            j++;
        }

        Shooting();

    }

    void PointGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mousePos - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        if (Input.GetButton("Slow")) transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        else transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed / 4 * Time.deltaTime);
    }

    void Shooting()
    {
        if (!isShooting) return;

        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Slow") && Input.GetButton("PlayerFire") && cooldownTimer <= 0)
        {
            GetComponent<AudioSource>().Play();

            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            // 2nd
            offset = transform.rotation * new Vector3(-0.3f, 0, 0);
            Instantiate(bulletPrefab2, transform.position + offset, transform.rotation);
            // 3rd
            offset = transform.rotation * new Vector3(0.3f, 0, 0);
            Instantiate(bulletPrefab2, transform.position + offset, transform.rotation);
            // 2nd
            offset = transform.rotation * new Vector3(-0.6f, 0, 0);
            Instantiate(bulletPrefab2, transform.position + offset, transform.rotation);
            // 3rd
            offset = transform.rotation * new Vector3(0.6f, 0, 0);
            Instantiate(bulletPrefab2, transform.position + offset, transform.rotation);
        }
        else if (Input.GetButton("PlayerFire") && cooldownTimer <= 0)
        {
            GetComponent<AudioSource>().Play();

            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            // The 30' degrees bullets
            Quaternion rot = Quaternion.identity;

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            /*
            // 2nd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 25);
            Instantiate(bulletPrefab, transform.position + offset, rot);
            // 3rd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -25);
            Instantiate(bulletPrefab, transform.position + offset, rot);
            */
        }
    }
}
