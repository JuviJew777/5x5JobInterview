using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject mySpawner;
    [SerializeField]
    GameObject NextLevel, enemySpawner, gameOver;

    int currentLevel;
    int maxlevel = 1;

    GameObject MasterManager;

    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }

    // Start is called before the first frame update
    void Start()
    {
        //Sets Variables at start
        MasterManager = GameObject.FindGameObjectWithTag("Manager");
        if (MasterManager != null)
        {
            CurrentLevel = MasterManager.GetComponent<MainManager>().SelectedLevel;
        }
        else
            CurrentLevel = 0;
        mySpawner = transform.GetChild(0).gameObject;
        enemySpawner.GetComponent<EnemySpawner>().StartEnemys();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If no enemys in screen Calls Next Level
        if (mySpawner.transform.childCount <= 0)
        {
            if (CurrentLevel < maxlevel)
            {
                NextLevel.SetActive(true);

            }
            else
            {
                gameOver.SetActive(true);
            }

        }   
    }

    public void GameOver()
    {
        //If we lose or win all levels the game over will show up
        enemySpawner.SetActive(false);
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        //restart Game with the next level 
        CurrentLevel++;
        GetComponent<ReadFile>().LevelUp(CurrentLevel);
        enemySpawner.GetComponent<EnemySpawner>().StartEnemys();
        Debug.Log(CurrentLevel + " " + maxlevel);
        NextLevel.SetActive(false);
        
    }
}
