using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3.0f;

    public float moveSpeed = 350.0f;

    public float damage = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed  *  transform.forward;
    }

    /*
    private void OnTriggerEnter(Collider other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Enemy") //if other object from parameter is tagged enemy
        {
            other.GetComponent<Enemy>().takeDamage(damage); //execute takeDamage (see enemy script)
            Destroy(this.gameObject); //destroy projectile
        }
    }
    */
}
