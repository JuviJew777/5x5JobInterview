using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int[,] map = new int[,] 
    { {0,1,1,1,1,1,0},
      {0,1,1,1,1,1,0},
      {0,1,1,1,1,1,0},
      {0,1,1,1,1,1,0}
    };

    int[,] map2 = new int[,]
    { {1,0,1,0,1,0,1},
      {0,1,0,1,0,1,0},
      {1,0,1,0,1,0,1},
      {0,1,0,1,0,1,0}
    };

    [SerializeField]
    GameObject [] enemyPrefab;

    [SerializeField]
    float xOffSet, yOffSet;


    ReadFile Manager;

    public float XOffSet { get => xOffSet; set => xOffSet = value; }

    // Start is called before the first frame update
    void Start()
    {
        //The manager is now the current father of this Game Object
        Manager = transform.parent.gameObject.GetComponent<ReadFile>();
        CalculateOffset();
        //StartEnemys();
        
    }

    void CalculateOffset()
    {
        //Calculate the offset for Screen fit
        Rect rect = GameObject.Find("Canvas").GetComponent<RectTransform>().rect;
        float objectwidth = enemyPrefab[0].GetComponent<RectTransform>().rect.width;
        objectwidth = Mathf.Abs(rect.width / objectwidth);

        xOffSet = (float)(rect.width / objectwidth) / 2;
        Debug.Log(xOffSet);
    }

    public void StartEnemys()
    {
        //Public Function that Calls Instantiate enemys
        InstantiateEnemys(Manager.Mymap);
    }

    void InstantiateEnemys(int[,] map)
    {
        //Read 2D Array for instantiate the enemys
        for (int i = 0; i < 4; ++i)
        {

            for (int j = 0; j < 7; ++j)
            {
                if (map[i, j] != 0)
                {
                    GameObject newEnemy = Instantiate(enemyPrefab[Random.Range(0,3)], gameObject.transform);
                    newEnemy.transform.position = new Vector3(transform.position.x + (j * XOffSet), transform.position.y + (i * yOffSet), 0);
                }
            }

        }
    }

    void InstantiateEnemys(string[] map)
    {
        //Read 2D Array for instantiate the enemys
        for (int i = map.Length-1; i >= 0; --i)
        {
            for (int j = 0; j < 7; ++j)
            {
                if (map[i][j] != '0')
                {
                    int valueChar = (int)(map[i][j] - '0') - 1;
                    GameObject newEnemy = Instantiate(enemyPrefab[valueChar], gameObject.transform);
                    newEnemy.transform.position = new Vector3(transform.position.x + (j * XOffSet), transform.position.y + (-i * yOffSet), 0);
                    //Debug.Log(valueChar);
                }
            }

        }
    }

    
}
