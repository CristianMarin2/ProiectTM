using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public string goalName = "Goal1"; 
    public BallHandler ballHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("GOAL in " + goalName + "!");

            if (goalName == "Goal1")
            {
                // Team 2 scored
            }
            else if (goalName == "Goal2")
            {
                // Team 1 scored
            }

            // Reset game
            ballHandler.ResetPositions();
        }
    }
}