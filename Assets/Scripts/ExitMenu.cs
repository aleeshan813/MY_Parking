using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
