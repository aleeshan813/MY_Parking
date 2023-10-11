using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WinMenu : MonoBehaviour
{
    public GameObject WinPanel;
    [SerializeField] TextMeshProUGUI scoretext;

    private void Awake()
    {
        WaitAndHidePanel();
    }

    public void Pause()
    {
        WinPanel.SetActive(true);
        StartCoroutine(WaitAndHidePanel());
    }

    private IEnumerator WaitAndHidePanel()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }

    public void NextLevel(int level)
    {
        UnlockNewLevel(level);
        string levelName = "level-" + level;
        SceneManager.LoadScene("Level-" + level.ToString());
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void UnlockNewLevel(int level)
    {
        int nextLevelIndex = level + 1;

        if (nextLevelIndex > PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", nextLevelIndex);
            PlayerPrefs.SetInt("UnlockedLevel", nextLevelIndex);
            PlayerPrefs.Save();
        }
    }

    public void DisplayScore(int score)
    {
        // Get the score from the ScoreManager and display it
        scoretext.text = "Score: " + score;
    }
}
