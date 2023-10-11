using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausPanel;
    bool continueing = false;
   /* [SerializeField] GameObject VolumePanel;*/
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (continueing == false)
            {
                continueing = true;
                Pause();
            }
            else
            {
                continueing = false;
                Continue();
            }
            
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry(int level)
    {
        string levelName = "level-" + level;
        SceneManager.LoadScene("Level-" + level.ToString());
        Continue();
    }

    /* public void volume()
     {
         VolumePanel.SetActive(true);
         PausPanel.SetActive(false);
     }*/

    public void Pause()
    {
        PausPanel.SetActive(!PausPanel.activeSelf);
        {
            Time.timeScale = 0f;
        }
    }
    public void Continue()
    {
        PausPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
