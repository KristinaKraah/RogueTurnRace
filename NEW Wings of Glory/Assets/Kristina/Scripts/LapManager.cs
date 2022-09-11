using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    public TextMeshProUGUI laps;

    private void Start()
    {
        laps.text = "Lap: 1";
    }

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
                laps.text = "Lap: " + player.lapNumber.ToString();

                if(player.lapNumber > totalLaps)
                {
                    //End the race
                    Debug.Log("Finished race");
                }
            }
        }

    }
}
