using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerCheckpoint>())
        {
            PlayerCheckpoint player = collision.gameObject.GetComponent<PlayerCheckpoint>();
            if(player.checkpointIndex == checkpoints.Count)
            {
                player.checkpointIndex = 0;
                player.lapNumber++;

                Debug.Log($"You are on lap {player.lapNumber} out of {totalLaps}");

                if(player.lapNumber > totalLaps)
                {
                    //End the race
                    Debug.Log("Finished race");
                }
            }
        }

    }
}
