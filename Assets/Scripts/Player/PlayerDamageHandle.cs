using UnityEngine;

public class PlayerDamageHandle : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Health;           // Look in the DamageHandler 4 more info

    public int health = 1;
    private float realHealth = 100;

    private SpriteRenderer healthBar;           // Reference to the sprite renderer of the health bar.
    private Vector3 healthScale;                // The local scale of the health bar initially (with full health).

    public float invulnPeriod = 0;
    float invulnTimer = 0;

    SpriteRenderer spriteRend;

    void Start()
    {

        // NOTE!  This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }

        // INIT
        Health = (GameObject)Instantiate(Health, transform.position, transform.rotation);
        healthBar = Health.GetComponent<SpriteRenderer>();
        healthScale = healthBar.transform.localScale;
    }

    void OnTriggerEnter2D()
    {
        realHealth -= 100f / health;

        UpdateHealthBar();

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    void Update()
    {
        Health.transform.position = transform.position + new Vector3(-1.2f, 1f, 0);

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

    //set explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //set the position of the explosion
        explosion.transform.position = transform.position;
    }

    public void UpdateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - realHealth * 0.01f);

        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * realHealth * 0.01f, 1, 1);
    }
}
