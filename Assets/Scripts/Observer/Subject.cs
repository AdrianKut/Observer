using System.Collections.Generic;
using UnityEngine;

public abstract class Subject<T> : MonoBehaviour where T : Subject<T>
{
    public static T Instance;

    private List<IObserver> _observers;

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"There is another {typeof(T).Name} on scene!");
            return;
        }

        Instance = this as T;

        _observers = new List<IObserver>();
    }

    public void Register(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(EventID eventID)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnNotify(eventID);
        }
    }
}
