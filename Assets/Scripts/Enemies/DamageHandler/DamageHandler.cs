using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Health;
    [SerializeField] Vector3 healthOffset = new Vector3(-0.5f, 0.6f, 0);

    [SerializeField] int health = 1;
    [HideInInspector] public float realHealth = 100;

    private SpriteRenderer healthBar;
    private Vector3 healthScale;

    [SerializeField] float invulnPeriod = 0.1f;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }

        Health = (GameObject)Instantiate(Health, transform.position, Quaternion.identity);

        if (gameObject.layer == 13)
            Health.transform.parent = transform;

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
        Health.transform.position = transform.position + healthOffset;

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
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
            ActiveBarrett();
            Die();
        }

    }

    void Die()
    {
        NotifyScore();
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
        healthBar.transform.localScale = new Vector3(healthScale.x * realHealth * 0.01f, 1, 1);
    }

    void ActiveBarrett()
    {
        if (gameObject.name == "PlayerBarrett01(Clone)" || gameObject.name == "PlayerBarrett02(Clone)")
            gameObject.GetComponent<PBarrettShooting>().MaxBarrett();
    }

    void NotifyScore()
    {
        GameObject gameManagerObj = GameObject.FindWithTag("Manager");
        if (gameManagerObj != null)
        {
            var manager = gameManagerObj.GetComponent<ScorceManager>();
            manager?.UpdateScore(this.health*10);
        }
    }
}
