using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
    GameObject Cortina;
    bool splashEnded = false;

    public bool SplashEnded { get => splashEnded; set => splashEnded = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Cortina == null)
        {
            Cortina = GameObject.Find("Cortina");
        }
        //When the Splash Screen is over destroy it
        if (Cortina != null && splashEnded)
        {
            Debug.Log(splashEnded);

            Destroy(Cortina);
        }
    }
}
