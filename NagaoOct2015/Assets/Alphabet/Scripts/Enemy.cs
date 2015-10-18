using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour,ICollisionObserver
{
	public string alphabet;
    public ICollisionObservableContainer _ICollisionObservable;

    void Start()
    {
        _ICollisionObservable.Result.Add(this);
    }

    public void UpdateCollisionObserver(Collider2D c)
    {
        if (c.gameObject == gameObject)
        {
            Destroy(gameObject);
            _ICollisionObservable.Result.Remove(this);
        }
    }

}