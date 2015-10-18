using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour,ICollisionObservable {

    List<ICollisionObserver> observers = new List<ICollisionObserver>();
    Collider2D currentCollider;

    // Use this for initialization

    public void Add(ICollisionObserver observer)
    {
        Debug.Log("Adding:" + observer);
        observers.Add(observer);
    }
    public void Remove(ICollisionObserver observer)
    {
        Debug.Log("removing:" + observer);
        observers[observers.IndexOf(observer)] = null;
    }

    public void OnTriggerEnter2D (Collider2D c)
	{
        Debug.Log("collider");
        currentCollider = c;
        NotifyObservers();
	}

    void NotifyObservers()
    {
        observers.ForEach(arg => Debug.Log("notifying"+arg));
        observers.ForEach(arg => arg.UpdateCollisionObserver(currentCollider));
        observers.RemoveAll(arg => arg == null);
    }

}
