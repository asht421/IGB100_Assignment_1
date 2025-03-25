using UnityEngine;

public class EnemyNew : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;

    private bool canShoot;
    [SerializeField] private float fireRate;
    [SerializeField] private float health = 50.0f;

    [SerializeField] private float enemy1DamageToPlayer = 10.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;

    public GameObject deathEffect;

    private void Awake()
    { 
            rb= GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(xSpeed, ySpeed*-1);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().takeDamage(fallingEnemyDamage);
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }*/

    public void takeDamage(float damage)
    {
        health -= damage; // armour calculations could go here

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 0.333f);
            Destroy(this.gameObject);
        }
    }
    /*

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Time.time > damageTime) //the Time.time bit helps balance in case of poor framerate (dont want player to take damage every frame)
        {
            other.transform.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }*/
}
