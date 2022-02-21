using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    int penetration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Always send the bullet up when is created
        rb.velocity = Vector2.up.normalized * bulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy the bullet in 5 seconds if this didn't hit anything
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            
            //If bullet hits some enemy activate the enemy destroy animation
            collision.GetComponent<Enemy>().readHit();
            //if the bullet penetration is lees than 0 destroy the bullet
            if (penetration <= 0)
            {
                Destroy(gameObject);
            }
            else
                penetration--;
        }
    }
}
