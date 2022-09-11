using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUpgrade : MonoBehaviour
{
    public Upgrades upgradeScript;
    public bool onePlaying;

    public void Update()
    {
        onePlaying = upgradeScript.playerOnePlaying;
      
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            if (!onePlaying)
            {
               upgradeScript.upgradePanelPlayerTwo.SetActive(true);
            }
            else if (onePlaying)
            {
               upgradeScript.upgradePanelPlayerOne.SetActive(true);
            }
        }

  

    }
}
