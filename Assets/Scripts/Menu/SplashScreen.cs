using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    
    private void Start()
    {
       
    }

    void ShowMenu()
    {
        transform.parent.gameObject.GetComponent<Animator>().SetBool("Start", true);
        gameObject.SetActive(false);
        
    }

    void DeactivateObject()
    {
        GameObject Manager = GameObject.FindGameObjectWithTag("Manager");
        Manager.GetComponent<SplashManager>().SplashEnded = true;
        gameObject.SetActive(false);
    }
}
