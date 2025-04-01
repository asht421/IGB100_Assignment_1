using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    private Transform bulletPosition;

    [SerializeField] private float fireTime = 2.0f;
    [SerializeField] private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPosition = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        Shoot();
    }

    void Shoot()
    {
        if(timer > fireTime && transform.position.y > -3)
        {
            Instantiate(bullet, bulletPosition.position, Quaternion.identity);
            timer = 0;
        }
    }
}
