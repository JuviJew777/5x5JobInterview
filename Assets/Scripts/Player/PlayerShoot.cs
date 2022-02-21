using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject[] bullets;

    GameObject currentBullet;

    [SerializeField]
    float defaultFireRate;
    
    bool canFire;
     

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        currentBullet = bullets[0];
    }



    // Update is called once per frame
    void Update() //Listen to input and shoot if W or Up Arrow is true
    {
        if (canFire)
        {
            if(Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                GameObject newBullet = Instantiate(currentBullet);
                newBullet.name = "Bullet";
                newBullet.transform.position = gameObject.transform.position + new Vector3(0, .5f, 0);
                canFire = false;
                StartCoroutine(PrepareFire());
            }
        }
        
        
        
    }

    public void FireFire() //Createa prefab of the bullet
    {
        if (canFire)
        {
            GameObject newBullet = Instantiate(currentBullet);
            newBullet.name = "Bullet";
            newBullet.transform.position = gameObject.transform.position + new Vector3(0, .5f, 0);
            canFire = false;
            StartCoroutine(PrepareFire());
        }
    }

    IEnumerator PrepareFire() //Set time of shoot rate
    {
        yield return new WaitForSeconds(defaultFireRate);
        canFire = true;
    }

    public void SetGunType(int type) //Change the bullet if bonus catched
    {
        if(type < bullets.Length)
        {
            currentBullet = bullets[type];
        }
    }
    
}
