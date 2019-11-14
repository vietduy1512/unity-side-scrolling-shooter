using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;

    [SerializeField]
    float padding = 0.5f;

    [SerializeField]
    GameObject playerBullet;

    [SerializeField]
    float bulletSpeed = 10f;

    [SerializeField]
    float fireRate = 0.3f;

    Coroutine fireCoroutine;

    Vector2 Min;
    Vector2 Max;

    void Start()
    {
        SetupBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void SetupBoundaries()
    {
        Camera camera = Camera.main;
        Min.x = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        Max.x = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        Min.y = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        Max.y = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, Min.x, Max.x);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, Min.y, Max.y);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown(Constants.Event.FIRE_BULLET))
        {
            fireCoroutine = StartCoroutine(InstantiateFire());
        }
        if (Input.GetButtonUp(Constants.Event.FIRE_BULLET))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator InstantiateFire()
    {
        while (true)
        {
            GameObject pBullet = Instantiate(playerBullet, transform.position, Quaternion.identity);
            pBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            yield return new WaitForSeconds(fireRate);
        }
        
    }
}
