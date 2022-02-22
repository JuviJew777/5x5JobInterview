using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float enemySpeed;

    GameObject Manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Manager = GameObject.Find("Manager");
    }
    private void FixedUpdate()
    {
        //move down enemy
        rb.velocity = Vector2.down * enemySpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            //If enemy reach the deadzone the game ends
            Manager.GetComponent<LevelManager>().GameOver();
        }
    }

}
