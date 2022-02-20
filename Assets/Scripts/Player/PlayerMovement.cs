using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    float velocity;

    Vector3 movement;

    [SerializeField]
    GameObject Manager;

    Animator myAnim;

    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * velocity * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        
       
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bonus"))
        {
            Debug.Log("Bonusss");
            Bonus colBon = collision.gameObject.GetComponent<Bonus>();
            Manager.GetComponent<ScoreManaging>().StartBonus(colBon);
            Destroy(collision.gameObject);
        }
        else if(collision.transform.CompareTag("enemy"))
        {
            myAnim.SetBool("Destroyed", true);
        }
    }

    void DestroyPlayer()
    {
        Manager.GetComponent<LevelManager>().GameOver();
        Destroy(gameObject);
    }
}
