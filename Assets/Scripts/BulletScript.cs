using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rbody;
    public float force;

    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] public float damage = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rbody = GetComponent<Rigidbody2D>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 rotation = transform.position - mousePosition;
        rbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        //bullet rotated towards mouse
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //ensures bullets cannot damage ships as they spawn
        if(transform.position.y > 5){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) //parameter of colliding with other object
    {
        if (other.transform.tag == "Enemy") //if other object from parameter is tagged enemy
        {
            other.GetComponent<EnemyNew>().takeDamage(damage); //execute takeDamage (see enemy script)
            Destroy(this.gameObject); //destroy projectile
        }
    }
    
}
