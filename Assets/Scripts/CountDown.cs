using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : Subject
{
    public int CountDownTime;

    [SerializeField] TextMeshProUGUI CountDownDisplay; // Changed TextMeshPro to TextMeshProUGUI
    [SerializeField] AudioSource CountDown_audio;

    private void Start()
    {
        StartCoroutine(CountDownToStart()); // Start the countdown coroutine
    }

    IEnumerator CountDownToStart()
    {
        while (CountDownTime > 0)
        {
            CountDown_audio.Play();
            CountDownDisplay.text = CountDownTime.ToString();
            yield return new WaitForSeconds(1f);
            CountDownTime--;
        }

        NotifyObserver(PlayerAction.Gear_Controller_true);
        CountDownDisplay.text = "GO!";
        NotifyObserver(PlayerAction.Timer);
        
        yield return new WaitForSeconds(1f);

        Destroy(gameObject); // Destroy the countdown script component
    }
}
