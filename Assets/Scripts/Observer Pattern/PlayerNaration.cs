using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNaration :MonoBehaviour, IObserver
{
    [SerializeField] Subject _ExitPanelSubject;
    [SerializeField] Subject _PausePanelSubject;
    [SerializeField] Subject _GearSubject;
    [SerializeField] Subject _CountDownSubject;
    [SerializeField] Subject _TimerSubject;

    [SerializeField] GameObject ExitMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Gear_Controller;
    [SerializeField] GameObject Timer;

    public void OnNotify(PlayerAction action)
    {
        if (action == PlayerAction.ExitPanel_true)
        {
            ExitMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (action == PlayerAction.ExitPanel_false)
        {
            ExitMenu.SetActive(false);
        }

        if (action == PlayerAction.PausePanel_true)
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            {
                Time.timeScale = 0f;
            }
        }

        if (action == PlayerAction.PausePanel_false)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }

        if (action == PlayerAction.Gear_Controller_false)
        {
            Gear_Controller.SetActive(false);
        }

        if(action == PlayerAction.Gear_Controller_true)
        {
            Gear_Controller.SetActive(true);
        }

        if(action == PlayerAction.Timer)
        {
            Timer.SetActive(true);
        }
    }

    public void OnEnable()
    {
        _ExitPanelSubject.AddObserver(this);
        _PausePanelSubject.AddObserver(this);
        _GearSubject.AddObserver(this);
        _CountDownSubject.AddObserver(this);
        _TimerSubject.AddObserver(this);
    }

    public void OnDisable()
    {
        _ExitPanelSubject.RemoveObserver(this);
        _PausePanelSubject.RemoveObserver(this);
        _GearSubject.RemoveObserver(this);
        _CountDownSubject.RemoveObserver(this);
        _TimerSubject.RemoveObserver(this);
    }
}
