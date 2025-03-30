using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float lifeTime = 5.0f;
    public float damage = 50.0f;

    public GameObject player;
    private Rigidbody2D rbody;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

    void OnTriggerEnter2D(Collider2D other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Player") //if other object from parameter is tagged enemy
        {
            other.GetComponent<Player>().takeDamage(damage); //execute takeDamage (see player script)
            Destroy(this.gameObject); //destroy projectile
        }

    }
}
