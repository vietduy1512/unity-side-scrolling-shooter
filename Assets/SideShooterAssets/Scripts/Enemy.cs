using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetwenShots = 0.2f;
    [SerializeField] float maxTimeBetwenShots = 3f;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] float bulletSpeed = 10f;

    void Start()
    {
        shotCounter = GetRandomCounter();
    }

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = GetRandomCounter();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
    }

    private float GetRandomCounter() => Random.Range(minTimeBetwenShots, maxTimeBetwenShots);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBulletCollision(collision.gameObject.GetComponent<DamageDealer>());
    }

    private void OnBulletCollision(DamageDealer damageDealer)
    {
        if (!damageDealer) return;

        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
