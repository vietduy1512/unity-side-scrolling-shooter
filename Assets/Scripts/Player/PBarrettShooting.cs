using UnityEngine;

public class PBarrettShooting : MonoBehaviour
{
    [SerializeField] Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float rotSpeed = 180f;

    [SerializeField] float fireDelay = 0.25f;

    float cooldownTimer = 0;

    void Start()
    {

    }

    void Update()
    {

        PointGun();
        cooldownTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

        }
    }

    void PointGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mousePos - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }

    public void MaxBarrett()
    {
        GameObject player = GameObject.Find("PlayerShip(Clone)");
        if (player != null)
            player.GetComponent<PlacingBarrett>().j--;
    }
}
