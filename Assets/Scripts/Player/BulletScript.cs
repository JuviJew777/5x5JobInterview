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
        rb.velocity = Vector2.up.normalized * bulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            
            //Debug.Log("Choque");
            collision.GetComponent<Enemy>().AnimActivator();
            if (penetration <= 0)
            {
                Destroy(gameObject);
            }
            else
                penetration--;
        }
    }
}
