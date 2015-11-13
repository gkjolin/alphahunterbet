using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour,ICollisionObservable, IGameLogicObserver
{

    List<ICollisionObserver> observers = new List<ICollisionObserver>();
    Collider2D currentCollider;

    // Use this for initialization

    bool _isActive =true;

    public bool isActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    public void Add(ICollisionObserver observer)
    {
        if (!_isActive) return;
        observers.Add(observer);
    }

    public void Remove(ICollisionObserver observer)
    {
        if (!_isActive) return;
        observers[observers.IndexOf(observer)] = null;
    }

    public void OnTriggerEnter2D (Collider2D c)
	{
        if (!_isActive) return;
        currentCollider = c;
        NotifyObservers();
	}

    void NotifyObservers()
    {
        if (!_isActive) return;
        observers.RemoveAll(arg => arg == null);
        observers.ForEach(arg => arg.UpdateCollisionObserver(currentCollider));
        observers.RemoveAll(arg => arg == null);
    }

    void Start()
    {
        GameObject.Find("GameLogic").GetComponent<GameLogic>().Add(this);
    }

    public void UpdateObserver(GameLogic observable)
    {
        if (observable.isClear) { _isActive = false; }
    }

}
