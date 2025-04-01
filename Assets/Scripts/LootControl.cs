using UnityEngine;

public class LootControl : MonoBehaviour
{
    private string type;

    Rigidbody2D rbody;

    public float xSpeed;
    public float ySpeed;
    private GameObject pickup;

    public int points;
    public Loot lootScript;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lootScript = GetComponent<Loot>(); //doesnt work with scriupatble objecct
        //points = lootScript.value;
        //Debug.Log(points);
    }

    // Update is called once per frame
    void Update()
    {
        rbody.linearVelocity = new Vector2(xSpeed, ySpeed * -1);

        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Player") //if other object from parameter is tagged player
        {
            //other.GetComponent<GameManager>().TakePoints(points);
            GameManager.instance.TakePoints(points);
            Destroy(this.gameObject);
        }

    }
}
