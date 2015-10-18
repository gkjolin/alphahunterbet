using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour
{

    List<IPlayerModelObserver> observers = new List<IPlayerModelObserver>();

    void Start()
    {
    }

    public void Add(IPlayerModelObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyPlayerModelObservers()
    {
        observers.ForEach(arg => arg.UpdateObserver(this));
    }
}
