using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManaging : MonoBehaviour
{
    int score;

    [SerializeField]
    Text scoreTxt;

    int multiplier;
    public int Score { get => score; set => score = value; }

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
        Score = 0;
    }

    //The text object will show te current score 
    void FixedUpdate()
    {

        scoreTxt.text = "Score: " + (Score);
    }

    //Add score to de variable
    public void AddScore(int Score)
    {
        this.Score += Score * multiplier;
    }

    //Read for taken bonus
    public void StartBonus(Bonus currentBonus)
    {
        switch (currentBonus.Type)
        {
            case "2X":
                //Debug.Log("StartBonus");
                StartCoroutine(StartMultiplier(currentBonus.Time));
                break;
            case "HardShot":
                Debug.Log("StartBonus");
                StartCoroutine(ChangeGun(1));
                break;

            default:
                break;
        }
    }


    //Corrutine for New Gun 
    IEnumerator ChangeGun(int Type)
    {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if(Player != null)
        {
            Player.GetComponent<PlayerShoot>().SetGunType(Type);
            this.GetComponent<BonusManagment>().SetPowerUp(true);
            yield return new WaitForSeconds(10);
            Player.GetComponent<PlayerShoot>().SetGunType(0);
            this.GetComponent<BonusManagment>().SetPowerUp(false);
        }
        
    }

    //Corrutine for 2XP
    IEnumerator StartMultiplier(float time)
    {
        multiplier = 2;
        this.GetComponent<BonusManagment>().SetBonusState(true);
        yield return new WaitForSeconds(time);
        multiplier = 1;
        this.GetComponent<BonusManagment>().SetBonusState(false);
    }
}
