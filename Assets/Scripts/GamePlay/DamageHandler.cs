using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

    public GameObject Explosion;
	public GameObject Health;
	public Vector3 healthOffset = new Vector3(-0.5f, 0.6f, 0);

	public int health = 1;
	[HideInInspector] public float realHealth = 100;

	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).

	public float invulnPeriod = 0.1f;
	float invulnTimer = 0;
	int correctLayer;

	SpriteRenderer spriteRend;

	void Start() {
		correctLayer = gameObject.layer;

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}

		// INIT
		Health = (GameObject)Instantiate(Health, transform.position, transform.rotation); // Create GO

		if(gameObject.layer == 13)
			Health.transform.parent = transform;

		healthBar = Health.GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
	}

	void OnTriggerEnter2D() {
		realHealth -= 100f / health;

		UpdateHealthBar();

		if(invulnPeriod > 0) {
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}
	}

    void Update()
    {	
		// Update the position of Health
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
			ActiveBarrett ();
            Die();
        }

    }

	void Die() {
		Destroy(gameObject);
		Destroy (Health);
	}

    //set explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate (Explosion);

        //set the position of the explosion
        explosion.transform.position = transform.position;
    }

	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - realHealth * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * realHealth * 0.01f, 1, 1);
	}

	void ActiveBarrett()
	{
		if(gameObject.name == "PlayerBarrett01(Clone)" || gameObject.name == "PlayerBarrett02(Clone)")
			gameObject.GetComponent<PBarrettShooting> ().MaxBarrett ();
	}
}
