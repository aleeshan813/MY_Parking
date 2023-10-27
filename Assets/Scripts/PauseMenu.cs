using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : Subject
{
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
        NotifyObserver(PlayerAction.PausePanel_true);
    }
    public void Continue()
    {
        NotifyObserver(PlayerAction.PausePanel_false);
    }
}
