using UnityEngine;

public class PBarrettShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;

    public float rotSpeed = 180f;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        PointGun();
        cooldownTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldownTimer <= 0)
        {
            // SHOOT!
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            // Creat Bullets
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

        }
    }

    void PointGun()
    {
        // MousePosition to point gun
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Faces the mouse
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
