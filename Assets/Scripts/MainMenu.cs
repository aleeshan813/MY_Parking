using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] TextMeshProUGUI pointstext;

    public void Start()
    {
        Points();
    }

    public void levelSelector()
    {
        SceneManager.LoadScene(1);
    }

    public void Newgame()
    {
        // Reset the unlocked level to 1
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.Save();
        // Load the first level
        SceneManager.LoadScene("Level-1");
    }

    public void play()
    {
        // Retrieve the unlocked level from PlayerPrefs
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Ensure the unlocked level is within the valid range
        if (unlockedLevel >= 1 && unlockedLevel <= SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the unlocked level
            SceneManager.LoadScene("Level-" + unlockedLevel);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Volume()
    {

    }

    public void Points()
    {
        // Get the score from the ScoreManager and display it
        int score = ScoreManager.Instance.GetScore();
        pointstext.text = "Total Points: " + score;
    }
}
