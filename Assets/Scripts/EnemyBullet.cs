using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] public float damage = 50.0f;

    public GameObject player;
    [SerializeField] private float speed = 1.0f;
    private float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Follow()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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
