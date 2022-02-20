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

    public void SetBonusState(bool state)
    {
        myBonus.SetActive(state);
    }

    public void SetPowerUp(bool state)
    {
        powerUp.SetActive(state);
    }
}
