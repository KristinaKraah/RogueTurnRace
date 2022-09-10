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

    public bool playerOnePlaying;


    CarController carController;

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
        playerOnePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        

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
            speedChange = GameObject.FindObjectOfType<CarController>().MaxSpeed;
            speedChange = playerOneSpeed;

            playerTwo.SetActive(false);
            playerOne.SetActive(true);
        }


        else if (playerOnePlaying == false)
        {
            speedChange = GameObject.FindObjectOfType<CarController>().MaxSpeed;
            speedChange = playerTwoSpeed;

            playerOne.SetActive(false);
            playerTwo.SetActive(true);
        }
    }

    public void SpeedUpgradePlayerOne()
    {
        
        playerOneSpeed += 5f;
        playerOnePlaying = false;

        upgradePanelPlayerOne.SetActive(false);
    }

    public void SpeedUpgradePlayerTwo()
    {

        playerTwoSpeed += 5f;
        playerOnePlaying = true;

        upgradePanelPlayerTwo.SetActive(false);
    }
}
