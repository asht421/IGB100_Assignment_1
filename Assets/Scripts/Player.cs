using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    private Vector2 position;

    [SerializeField] private float health = 100.0f;
    public float damage = 30.0f;

    public GameObject deathEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;


        Movement();
        Boundary();

        transform.position = position;
    }

    private void Movement()
    {
        //Right Movement
        if (Input.GetKey("d"))
            position.x += moveSpeed * Time.deltaTime;

        //Left movement
        if (Input.GetKey("a"))
            position.x -= moveSpeed * Time.deltaTime;

        //Up movement
        if (Input.GetKey("w"))
            position.y += moveSpeed * Time.deltaTime;

        //Down movement
        if (Input.GetKey("s"))
            position.y -= moveSpeed * Time.deltaTime;
    }

    private void Boundary()
    {
        //X Boundary Checks
        if (position.x > GameManager.instance.xBoundary)
            position.x = GameManager.instance.xBoundary;
        else if (position.x < -GameManager.instance.xBoundary)
            position.x = -GameManager.instance.xBoundary;

        //Y Boundary Checks
        if (position.y > GameManager.instance.yBoundary)
            position.y = GameManager.instance.yBoundary;
        else if (position.y < -GameManager.instance.yBoundary)
            position.y = -GameManager.instance.yBoundary;
    }

    
    public void takeDamage(float damage)
    {
        health -= damage; // armour calculations could go here

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
