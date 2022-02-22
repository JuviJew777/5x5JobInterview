using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int life,id,type;

    [SerializeField]
    GameObject[] BonusPrefabs;

    GameObject Player;
    public int Life { get => life; set => life = value; }
    public int Id { get => id; set => id = value; }
    public int Type { get => type; set => type = value; }

    bool valueChanged = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //If distance between enemy and player is less than 5 points get down to 0
        readDistance(Player.transform.position);

        if(life <= 0)
        {
            AnimActivator();
        }
    }

    void readDistance(Vector3 Player)
    {
        float res = Vector3.Distance(Player, gameObject.transform.position);

        if (res < 5 && !valueChanged)
        {
            type -= 1;
            valueChanged = true;
        }
        
    }

    public Enemy(int ID, int Life, int type)
    {
        id = ID;
        life = Life;
        this.type = type;
    }

    


    void AnimActivator()
    {
        //Activate the enemy destroy animation
        Animator myAnim = GetComponent<Animator>();
        myAnim.SetBool("Destroyed", true);
        GetComponent<CircleCollider2D>().enabled = false;
        //Debug.Log(type);

    }

    public void readHit()
    {
        life--;
    }

    void SpawnBonus(float randValue0)
    {
        //is 10% probability of spawn gun Bonus
        Debug.Log("Destruido");
        if(randValue0 > .9)
        {
            GameObject newBonus = Instantiate(BonusPrefabs[1]);
            newBonus.transform.position = gameObject.transform.position;
        }
        //is 30% probability of spawn 2Xp
        else if (randValue0 > .7)
        {
            GameObject newBonus = Instantiate(BonusPrefabs[0]);
            newBonus.transform.position = gameObject.transform.position;
        }
    }
    void DestroyEnemy()
    {
        //Destroy this gameobject
        SpawnBonus(Random.value);
        GameObject myManager = GameObject.Find("Manager");
        myManager.GetComponent<ScoreManaging>().AddScore(Type);
        type = 0;
        Destroy(gameObject);
    }
}
