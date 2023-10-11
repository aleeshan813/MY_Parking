using System.Collections.Generic;
using UnityEngine;

public class Parking_controller : MonoBehaviour
{
    private HashSet<GameObject> enteredTriggers = new HashSet<GameObject>();
    private bool allTriggersEntered = false;
    public Material parkArea;

    public int score = 0;

    [SerializeField] private Color greenColor = Color.green; // Assign the green in the Inspector
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject Timer;
    [SerializeField] Timer_ timer;
    [SerializeField] WinMenu menu;

    private void OnTriggerEnter(Collider other)
    {
        enteredTriggers.Add(other.gameObject);

        // Check if the game object has entered all four triggers
        if (enteredTriggers.Count == 4 && !allTriggersEntered)
        {
            allTriggersEntered = true;

            ChangeTriggersColor(greenColor);
            GameWinUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the exited collider from the HashSet
        enteredTriggers.Remove(other.gameObject);

        // If the game object exits one of the triggers, reset the allTriggersEntered flag
        if (allTriggersEntered && enteredTriggers.Count < 4)
        {
            allTriggersEntered = false;

            ChangeTriggersColor(Color.red);
        }
    }

    private void ChangeTriggersColor(Color newColor)
    {
        parkArea.color = newColor;
    }

    private void GameWinUI()
    {
        float remainingTime = timer.ReminingTime;

        // Calculate the score based on the remaining time
        
        if (remainingTime >= 150) // 2.5 minutes
        {
            score = 100;
        }   
        else if (remainingTime >= 180) // 3 minutes
        {
            score = 50;
        }
        else
        {
            score = 10;
        }
        ScoreManager.Instance.AddToScore(score);
        menu.DisplayScore(score);
        WinPanel.SetActive(true);
        Destroy(Timer);
    }
}
