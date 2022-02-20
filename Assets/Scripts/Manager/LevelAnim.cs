using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnim : MonoBehaviour
{
 

    void AnimEnded()
    {
        transform.parent.gameObject.GetComponent<LevelManager>().RestartGame();
    }
}
