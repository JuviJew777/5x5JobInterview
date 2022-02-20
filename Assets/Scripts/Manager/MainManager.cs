using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    int selectedLevel;

    public int SelectedLevel { get => selectedLevel; set => selectedLevel = value; }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }

    
}
