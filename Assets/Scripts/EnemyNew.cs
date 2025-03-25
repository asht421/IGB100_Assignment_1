using UnityEngine;

public class EnemyNew : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    [SerializeField] private float health = 50.0f;
    public GameObject deathEffect;

    public bool canShoot;
    public GameObject bullet;
    [SerializeField] public float fireRate = 2.0f;
    [SerializeField] private float bulletSpeed;

    [SerializeField] public float collisionDamage = 50.0f;

    private void Awake()
    { 
            rb= GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (canShoot)
            InvokeRepeating("Shoot", fireRate, fireRate);

        Destroy(gameObject, 20);
;    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(xSpeed, ySpeed*-1);
    }

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

    // Damage Player on Collision
    void OnTriggerEnter2D(Collider2D other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Player") //if other object from parameter is tagged player
        {
            other.GetComponent<Player>().takeDamage(collisionDamage); //execute takeDamage (see player script)
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 0.333f);
            Destroy(this.gameObject);
        }
    }
    
    void Shoot()
    {
        GameObject temp = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<EnemyBullet>().Follow();
    }
}
