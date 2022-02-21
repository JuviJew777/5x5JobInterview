using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadFile : MonoBehaviour
{
    string[] maps;

    string[] mymap;

    public string[] Mymap { get => mymap; set => mymap = value; }

    [SerializeField]
    Text Warning;

    GameObject MasterManager;
    // Start is called before the first frame update
    void Start()
    {
        MapToTxt();
        MasterManager = GameObject.FindGameObjectWithTag("Manager");
        int startLevel;
        if (MasterManager != null)
        {
            startLevel = MasterManager.GetComponent<MainManager>().SelectedLevel;
        }
        else
            startLevel = 0;

        Mymap = readMap(startLevel);
  
        
        
    }

    void MapToTxt()
    {
        TextAsset readFile = Resources.Load<TextAsset>("Maps") as TextAsset;
        

        string Allmaps = readFile.text;
        maps = Allmaps.Split('-');
       


        //Warning.text = readFile;
    }

    public void LevelUp(int level)
    {

        Debug.Log(level);
        mymap = readMap(level);
    }

    string[] readMap(int level)
    {
        string[] mapLines = maps[level].Split('\n');
        if(level < maps.Length)
        {
            for(int i = 0; i< mapLines.Length; ++i)
            {
                string line = "";
                for(int j = 0; j < mapLines[i].Length;++j)
                {
                    if(mapLines[i][j] != ',')
                    {
                        line += mapLines[i][j];
                    }
                }
                mapLines[i] = line;
                //Debug.Log(line);
            }
            return mapLines;
        }
        return null;
    }
}
