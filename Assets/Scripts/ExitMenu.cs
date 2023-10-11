using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitMenu : MonoBehaviour
{
    public GameObject ExitPanel;
    //public AudioSource AudioSource;

    public void Pause()
    {
        ExitPanel.SetActive(true);
        StartCoroutine(WaitAndHidePanel());
    }

    private IEnumerator WaitAndHidePanel()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
    public void GameOver(int level)
    {
        string levelName = "level-" + level;
        SceneManager.LoadScene("Level-" + level.ToString());
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
