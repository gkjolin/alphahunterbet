using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour,IPlayerModelObserver,IGameLogicObservable {

    public IPlayerModelObservableContainer _IPlayerModelObservableContainer;

    public GameObject player;
    public GameObject clearAnimation;
    public GameObject dyingAnimation;

    List<IGameLogicObserver> observers = new List<IGameLogicObserver>();
    public void Add (IGameLogicObserver observer)
    {
        observers.Add(observer);
    }

    bool _isDead;
    public bool isDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    bool _isClear;
    public bool isClear
    {
        get { return _isClear; }
        set { _isClear = value; }
    }

    // Use this for initialization
    void Start () {
        _IPlayerModelObservableContainer.Result.Add(this);

    }
	
	// Update is called once per frame
	public void UpdateObserver (IPlayerModelObservable observable) {
        isClear = (observable.leftToCollect == 0);
        isDead = (observable.hitPoint <= 0);
        NotifyGameLogicObservers();
	}

    void NotifyGameLogicObservers()
    {
        observers.ForEach(arg => arg.UpdateObserver(this));
    }
}
