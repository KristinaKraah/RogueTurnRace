using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 10;
    public GameObject gameOverPanel;
    Upgrades upgrades;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
            {
            TakeDamage(1);
            Debug.Log("Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0) //calls what happens when health is 0
        {
            Debug.Log("GameOver");
            gameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage; //subtracts the damage from the health amount
        healthBar.fillAmount = healthAmount / 10; //changes the fill amount divided by max health
    }

   
}
