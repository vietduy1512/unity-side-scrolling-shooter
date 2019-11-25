using UnityEngine;

public class BossShoot01 : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float requirePosition = 5f;

    public float fireDelay = 0.50f;

    public float waveDelay = 4f;
    float cooldownTimer = 0f;

    int i = 0;
    float waveDelayTemp;

    Transform player;

    Vector3 offset;

    void Start()
    {
        waveDelayTemp = waveDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            // Find the player's ship!
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (i == 9) waveDelayTemp -= Time.deltaTime;
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < requirePosition)
        {
            // SHOOT!
            cooldownTimer = fireDelay;

            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet;

        if (i == 0)
        {
            i++;

            offset = transform.rotation * new Vector3(-2f, 0f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -0.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-0.75f, 2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-0.75f, -3.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 1)
        {
            i++;
            offset = transform.rotation * new Vector3(-2f, 0.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -0.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-1.25f, 2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-1.25f, -3.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 2)
        {
            i++;
            offset = transform.rotation * new Vector3(-2f, 0.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -1.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, 2.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 3)
        {
            i++;
            offset = transform.rotation * new Vector3(-2f, 1.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -1.6f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, 1.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -2.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;

        }
        else if (i == 4)
        {
            i++;
            offset = transform.rotation * new Vector3(-2f, 1.6f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, 1.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -1.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 5)
        {
            i++;
            offset = transform.rotation * new Vector3(-2f, 2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2f, -2.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, 1f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -1.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 6)
        {
            i++;
            offset = transform.rotation * new Vector3(-1.5f, 2.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-1.5f, -2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, 0.6f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -1f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 7)
        {
            i++;
            offset = transform.rotation * new Vector3(-1f, 2.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-1f, -2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, 0.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -0.6f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 8)
        {
            i++;
            offset = transform.rotation * new Vector3(-0.5f, 2.4f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-0.5f, -2.8f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
            offset = transform.rotation * new Vector3(-2.5f, -0.2f, 0);
            bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.transform.parent = gameObject.transform;
        }
        else if (i == 9 && waveDelayTemp <= 0)
        {
            waveDelayTemp -= Time.deltaTime;
            i = 0;
            waveDelayTemp = waveDelay;
        }
    }
}
