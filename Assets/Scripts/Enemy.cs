using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private float distance;
   
    public float health = 100.0f;

    public float damage = 25.0f;
    private float damageRate = 0.2f;
    private float damageTime;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Enemy movement = beeline for player
    private void Movement()
    {
        /*
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        /////////
        if(GameManager.instance.player)
            transform.LookAt(GameManager.instance.player.transform.position);

        transform.position += transform.up * moveSpeed * Time.deltaTime;
        */
    }

    /*
    public void takeDamage(float damage)
    {
        health -= damage; // armour calculations could go here

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player" && Time.time > damageTime) //the Time.time bit helps balance in case of poor framerate (dont want player to take damage every frame)
        {
            other.transform.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
    */
}
