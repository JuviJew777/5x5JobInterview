using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerMenu : MonoBehaviour
{
    GameObject MenuManager;
    // Start is called before the first frame update
    void Start()
    {
        MenuManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Call and set the Main Manager level value
    //Then change Scene
    public void LevelSelect(int level)
    {
        MenuManager.GetComponent<MainManager>().SelectedLevel = level;
        SceneManager.LoadScene(1);
    }

    //Change scene to Credits
    public void Credtis()
    {

        SceneManager.LoadScene(2);
    }
}
