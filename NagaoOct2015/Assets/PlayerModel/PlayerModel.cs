using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour,IPlayerModelObservable
{

    int _leftToCollect = 3;

    public int leftToCollect
    {
        get {
            return _leftToCollect;
        }
        set{
            _leftToCollect = value;
            NotifyPlayerModelObservers();
        }
    }

    float _hitPoint;

    public float hitPoint
    {
        get
        {
            return _hitPoint;
        }
        set
        {
            _hitPoint = value;
            NotifyPlayerModelObservers();
        }
    }


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
