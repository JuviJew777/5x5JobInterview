using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnim : MonoBehaviour
{
 
    //When Next Level Object animation ends the game restart with the next level
    void AnimEnded()
    {
        transform.parent.gameObject.GetComponent<LevelManager>().RestartGame();
    }
}
