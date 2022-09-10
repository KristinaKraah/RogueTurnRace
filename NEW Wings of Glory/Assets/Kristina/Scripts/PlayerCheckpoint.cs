using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public Rigidbody2D rb;

    public int lapNumber;
    public int checkpointIndex;

    void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
