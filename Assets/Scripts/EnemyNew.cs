using UnityEngine;
using UnityEngine.UIElements;

public class EnemyNew : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    [SerializeField] private float health = 50.0f;
    public GameObject deathEffect;
    [SerializeField] private float lifeTime = 20.0f;

    [SerializeField] private float collisionDamage = 50.0f;

    public AudioSource deathAudio;

    private void Awake()
    { 
        rb= GetComponent<Rigidbody2D>();
        deathAudio= GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
;   }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(xSpeed, ySpeed * -1);

        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage; // armour calculations could go here

        if (health <= 0)
        {
            deathAudio.Play();
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 0.333f);
            Destroy(this.gameObject);
        }
    }

    // Damage Player on Collision
    void OnTriggerEnter2D(Collider2D other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Player") //if other object from parameter is tagged player
        {
            deathAudio.Play();
            other.GetComponent<Player>().takeDamage(collisionDamage); //execute takeDamage (see player script)
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 0.333f);
            Destroy(this.gameObject);
        }
    }
}
