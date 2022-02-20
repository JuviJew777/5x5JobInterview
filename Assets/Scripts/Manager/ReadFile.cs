using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFile : MonoBehaviour
{
    string[] maps;

    string[] mymap;

    public string[] Mymap { get => mymap; set => mymap = value; }

    GameObject MasterManager;
    // Start is called before the first frame update
    void Start()
    {
        string readFile = Application.streamingAssetsPath + "/Files/" + "Maps.txt";
        string Allmaps = File.ReadAllText(readFile);
        int startLevel;
        maps = Allmaps.Split('-');
        MasterManager = GameObject.FindGameObjectWithTag("Manager");
        if (MasterManager != null)
        {
            startLevel = MasterManager.GetComponent<MainManager>().SelectedLevel;
        }
        else
            startLevel = 0;

        Mymap = readMap(startLevel);
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
