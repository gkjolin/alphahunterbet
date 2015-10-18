using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour,ICollisionObservable {

    List<ICollisionObserver> observers = new List<ICollisionObserver>();
    Collider2D currentCollider;

    // Use this for initialization

    public void Add(ICollisionObserver observer)
    {
        observers.Add(observer);
    } 

	public void OnTriggerEnter2D (Collider2D c)
	{
        currentCollider = c;
        NotifyObservers();
	}

    void NotifyObservers()
    {
        observers.ForEach(arg => arg.UpdateCollisionObserver(currentCollider));
    }

}
