using UnityEngine;
using TMPro;

public class Timer_ : Subject
{

    [SerializeField] TextMeshProUGUI timerText;
    public float ReminingTime;
    [SerializeField]CarController carController;
    // Update is called once per frame
    void Update()
    {
        if (ReminingTime > 0) ReminingTime -= Time.deltaTime;

        else if (ReminingTime < 0)
        {
            ReminingTime = 0;
            NotifyObserver(PlayerAction.ExitPanel_true);
            carController.enabled = false;
            NotifyObserver(PlayerAction.Gear_Controller_false);
        }   
       
        int minutes = Mathf.FloorToInt(ReminingTime / 60);
        int seconds = Mathf.FloorToInt(ReminingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
