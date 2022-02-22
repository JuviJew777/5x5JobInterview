using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BonusManagment : MonoBehaviour
{
    [SerializeField]
    GameObject myBonus,powerUp;


    // Start is called before the first frame update
    void Start()
    {
        SetBonusState(false);
        SetPowerUp(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Change the state of UIvisual Bonus in the game
    public void SetBonusState(bool state)
    {
        myBonus.SetActive(state);
    }

    //Change the state of UIvisual Bonus in the game
    public void SetPowerUp(bool state)
    {
        powerUp.SetActive(state);
    }
}
