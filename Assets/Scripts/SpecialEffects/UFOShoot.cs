using UnityEngine;

public class UFOShoot : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float requirePosition = 5f;

    [SerializeField] float fireDelay = 0.50f;

    [SerializeField] float waveDelay = 3f;
    float cooldownTimer = 0;

    int i = 0;
    float waveDelayTemp;

    Transform player;

    void Start()
    {
        waveDelayTemp = waveDelay;
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
        if (i == 9 && waveDelayTemp <= 0)
        {
            i = 0;
            waveDelayTemp = waveDelay;
        }
        else if (i == 9) waveDelayTemp -= Time.deltaTime;

        if (i != 9 && cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < requirePosition)
        {
            cooldownTimer = fireDelay;
            i++;

            Vector3 offset = transform.rotation * bulletOffset;

            // The 30' degrees bullets
            Quaternion rot = Quaternion.identity;

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            // 2nd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90);
            Instantiate(bulletPrefab, transform.position + offset, rot);
            // 3rd
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -90);
            Instantiate(bulletPrefab, transform.position + offset, rot);
            //4th
            rot.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 180);
            Instantiate(bulletPrefab, transform.position + offset, rot);

        }
    }
}
