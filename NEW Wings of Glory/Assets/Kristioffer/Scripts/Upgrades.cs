using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Upgrades : MonoBehaviour
{
    public GameObject upgradePanelPlayerOne;
    public GameObject upgradePanelPlayerTwo;

    public GameObject playerOne;
    public GameObject playerTwo;

    public float playerOneSpeed;
    public float playerTwoSpeed;
    public float speedChange;

    public float playerOneAcceleration;
    public float playerTwoAcceleration;
    public float accelerationChange;

    public float playerOneTurnSpeed;
    public float playerTwoTurnSpeed;
    public float turnSpeedChange;

    public bool playerOnePlaying;

    CarController carController;

    public TextMeshProUGUI speed;
    public TextMeshProUGUI laps;

    void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        upgradePanelPlayerOne.SetActive(false);
        upgradePanelPlayerTwo.SetActive(false);

        playerOneSpeed = 7f;
        playerTwoSpeed = 7f;
        speedChange = playerOneSpeed;

        playerOneAcceleration = 0.05f;
        playerTwoAcceleration = 0.05f;
        accelerationChange = playerOneAcceleration;

        playerOneTurnSpeed = 0.01f;
        playerTwoTurnSpeed = 0.01f;
        turnSpeedChange = playerOneTurnSpeed;


        playerOnePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        speed.text = (GameObject.FindObjectOfType<CarController>().Acceleration * 10f).ToString ("F0") + " km/h" ;

        //bytt til checkpoint/lap/neste player sin tur
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!playerOnePlaying)
            {
                upgradePanelPlayerTwo.SetActive(true);
            }
            else if (playerOnePlaying)
            {
                upgradePanelPlayerOne.SetActive(true);
            }
            
        }
        
        if (playerOnePlaying == true)
        {
            //speedChange = GameObject.FindObjectOfType<CarController>().MaxSpeed;
            speedChange = playerOneSpeed;
            accelerationChange = playerOneAcceleration;
            turnSpeedChange = playerOneTurnSpeed;

            playerTwo.SetActive(false);
            playerOne.SetActive(true);
        }


        else if (playerOnePlaying == false)
        {
            //speedChange = GameObject.FindObjectOfType<CarController>().MaxSpeed;
            speedChange = playerTwoSpeed;
            accelerationChange = playerTwoAcceleration;
            turnSpeedChange = playerTwoTurnSpeed;

            playerOne.SetActive(false);
            playerTwo.SetActive(true);
        }
    }

    //Player One Upgrades
    public void SpeedUpgradePlayerOne()
    {
        
        playerOneSpeed += 5f;
        playerOnePlaying = true;

        upgradePanelPlayerTwo.SetActive(false);
    }

    public void AccelerationUpgradePlayerOne()
    {

        playerOneAcceleration += 0.05f;
        playerOnePlaying = true;

        upgradePanelPlayerTwo.SetActive(false);
    }

    public void TurnSpeedUpgradePlayerOne()
    {

        playerOneTurnSpeed += 0.2f;
        playerOnePlaying = false;

        upgradePanelPlayerOne.SetActive(false);
    }


    //Player Two Upgrades
    public void SpeedUpgradePlayerTwo()
    {

        playerTwoSpeed += 5f;
        playerOnePlaying = false;

        upgradePanelPlayerOne.SetActive(false);
    }

    public void AccelerationUpgradePlayerTwo()
    {

        playerTwoAcceleration += 0.05f;
        playerOnePlaying = false;

        upgradePanelPlayerOne.SetActive(false);
    }

    public void TurnSpeedUpgradePlayerTwo()
    {

        playerTwoTurnSpeed += 0.2f;
        playerOnePlaying = true;

        upgradePanelPlayerTwo.SetActive(false);
    }
}
