using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerCheckpoint>())
        {
            PlayerCheckpoint player = collision.gameObject.GetComponent<PlayerCheckpoint>();
            if(player.checkpointIndex == index - 1)
            {
                player.checkpointIndex = index;
            }
        }
    }
   
}
