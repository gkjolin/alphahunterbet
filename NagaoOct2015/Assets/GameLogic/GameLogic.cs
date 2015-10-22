using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour,IPlayerModelObserver {

    public IPlayerModelObservableContainer _IPlayerModelObservableContainer;

    public GameObject playerView;
    public GameObject clearAnimation;
    public GameObject dyingAnimation;
    public GameObject playerCollision;

    List<IGameLogicObserver> observers = new List<IGameLogicObserver>();
    public void Add (IGameLogicObserver observer)
    {
        Debug.Log("observer:" + observer);
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
        Debug.Log("isDead:" + isDead);
        NotifyGameLogicObservers();
	}

    void NotifyGameLogicObservers()
    {
        observers.ForEach(arg => arg.UpdateObserver(this));
    }
}
