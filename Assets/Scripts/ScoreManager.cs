using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 100; // Initialize the score to 0

    // Create a static instance of ScoreManager to allow easy access from other scripts
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int points)
    {
        score += points;
    }
}
