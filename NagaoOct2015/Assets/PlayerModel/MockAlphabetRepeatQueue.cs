using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockAlphabetRepeatQueue : MonoBehaviour, IAlphabetQueueObservable
{

    List<IAlphabetQueueObserver> observers = new List<IAlphabetQueueObserver>();

    public string queueString
    {
        get { return "A"; }
    }

    bool _isRight;
    public bool isRight
    {
        get { return _isRight; }
        set { _isRight = value; }
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        isRight = true;
        observers.ForEach(arg => arg.UpdateAlphabetQueueObserver(this));
        yield return new WaitForSeconds(2.0f);
        isRight = false;
        observers.ForEach(arg => arg.UpdateAlphabetQueueObserver(this));
    }

    public void Add(IAlphabetQueueObserver observer)
    {
        observers.Add(observer);
    }


}
