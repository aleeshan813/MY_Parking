using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    HashSet<IObserver> observers = new HashSet<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer); 
    }

    protected void NotifyObserver(PlayerAction action)
    {
        foreach (IObserver observer in observers)
        {
            observer.OnNotify(action);
        }
    }

}
