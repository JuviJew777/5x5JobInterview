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
    
    float fireRate;
     

    // Start is called before the first frame update
    void Start()
    {
        fireRate = defaultFireRate;
        currentBullet = bullets[0];
    }



    // Update is called once per frame
    void Update()
    {
        if(fireRate <= 0)
        {
            if(Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                GameObject newBullet = Instantiate(currentBullet);
                newBullet.name = "Bullet";
                newBullet.transform.position = gameObject.transform.position + new Vector3(0,.5f,0);
                fireRate = defaultFireRate;
            }
        }
        else
            fireRate -= 1 * Time.deltaTime;
    }

    public void SetGunType(int type)
    {
        if(type < bullets.Length)
        {
            currentBullet = bullets[type];
        }
    }
    
}
