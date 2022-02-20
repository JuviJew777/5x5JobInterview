using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    string type;
    [SerializeField]
    float time;

    public Bonus(string type, float time)
    {
        this.type = type;
        this.time = time;
    }

    public float Time { get => time; set => time = value; }
    public string Type { get => type; set => type = value; }
}
