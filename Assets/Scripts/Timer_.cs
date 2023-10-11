using UnityEngine;
using TMPro;

public class Timer_ : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    public float ReminingTime;
    [SerializeField] GameObject ExitPanel;
    [SerializeField] GameObject Gear_Controller;
    [SerializeField]CarController carController;
    // Update is called once per frame
    void Update()
    {
        if (ReminingTime > 0) ReminingTime -= Time.deltaTime;

        else if (ReminingTime < 0)
        {
            ReminingTime = 0; ExitPanel.SetActive(true);
            carController.enabled = false;
            Gear_Controller.SetActive(false);
        }   
       
        int minutes = Mathf.FloorToInt(ReminingTime / 60);
        int seconds = Mathf.FloorToInt(ReminingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
