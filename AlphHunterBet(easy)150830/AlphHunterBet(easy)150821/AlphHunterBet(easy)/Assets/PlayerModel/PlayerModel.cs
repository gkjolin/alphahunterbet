using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour
{
    public int Number;
    public static int StageNumber;
    public int speed = 5;
    public string answer;

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
