using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GOverAnim : MonoBehaviour
{
    [SerializeField]
    ScoreManaging Manager;
    [SerializeField]
    Text scoreGo;

    Animator myAnim;

    GameObject MainManager;
    private void Start()
    {
        myAnim = GetComponent<Animator>();
        scoreGo.text = "Final Score: " + Manager.GetComponent<ScoreManaging>().Score.ToString();
        MainManager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void GoOut()
    {
        myAnim.SetBool("Reset", true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ResetGame()
    {
        if(MainManager != null)
        {
            MainManager.GetComponent<MainManager>().SelectedLevel = 0;
        }
        SceneManager.LoadScene(1);
    }
}
