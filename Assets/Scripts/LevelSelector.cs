using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Make sure unlockedLevel does not exceed the array length
        unlockedLevel = Mathf.Clamp(unlockedLevel, 0, buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i < unlockedLevel;
        }
    }

    // Update is called once per frame
    public void OnScene(int level)
    {
        string levelName = "level-" + level;
        SceneManager.LoadScene("Level-" + level.ToString());
    }
}
