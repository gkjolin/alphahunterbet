using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour,ICollisionObserver
{
	public string alphabet;
    public ICollisionObservableContainer _ICollisionObservable;

    public bool isAlive = true;

    void Start()
    {
       if (_ICollisionObservable.Result!=null)  _ICollisionObservable.Result.Add(this);
    }

    public void UpdateCollisionObserver(Collider2D c)
    {
        if (!isAlive) return;
        if (c.gameObject == gameObject)
        {
            Destroy(gameObject);
            _ICollisionObservable.Result.Remove(this);
        }
    }

}