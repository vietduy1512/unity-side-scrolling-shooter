using UnityEngine;

public class PlayerDamageHandle : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Health;

    private float realHealth = 100;

    private SpriteRenderer healthBar;
    private Vector3 healthScale;

    [SerializeField] float invulnPeriod = 0;
    float invulnTimer = 0;

    SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }

        Health = (GameObject)Instantiate(Health, Health.transform.position, Quaternion.identity);
        healthBar = Health.transform.GetChild(0).GetComponent<SpriteRenderer>();
        healthScale = healthBar.transform.localScale;
    }

    void OnTriggerEnter2D()
    {
        realHealth -= 100f / PlayerUpgradeManager.health;

        UpdateHealthBar();

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = 8;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (realHealth <= 0)
        {
            PlayExplosion();
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(Health);
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }

    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - realHealth * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * realHealth * 0.01f, healthScale.y, healthScale.z);
    }
}
