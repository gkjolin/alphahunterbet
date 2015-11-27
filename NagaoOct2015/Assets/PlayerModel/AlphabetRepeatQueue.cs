using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetRepeatQueue : MonoBehaviour, ICollisionObserver, IAlphabetQueueObservable {
	
	Queue<string> alphabetQueue = new Queue<string>{};
    public string answer;
    public ICollisionObservableContainer _ICollisionObservableContainer;
    Queue<string> lastQueue;

    List<IAlphabetQueueObserver> observers = new List<IAlphabetQueueObserver>();

    public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
	}
    bool _isRight;
    public bool isRight
    {
        get { return _isRight; }
        set { _isRight = value; }
    }
    public string queueString
    {
        get { return GetQueueString(); }
    }

    void Start()
    {
        _ICollisionObservableContainer.Result.Add(this);
    }

    public void Add(IAlphabetQueueObserver observer)
    {
        observers.Add(observer);
    }

    public void UpdateCollisionObserver(Collider2D c)
    {
        lastQueue = new Queue<string>(alphabetQueue);
        UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet, answer);
        isRight = ValidateQueue(answer);
        if (!isRight) alphabetQueue = new Queue<string>(lastQueue);
        Debug.Log("miss does not clear queue");
        observers.ForEach(arg => arg.UpdateAlphabetQueueObserver(this));
    }

    public void UpdateQueue(string newAlphabet, string answerString){				
		alphabetQueue.Enqueue(newAlphabet);
		if(alphabetQueue.Count > answerString.Length){
			alphabetQueue.Dequeue ();
		}
	}
	
	public string GetQueueString(){
		return string.Concat (alphabetQueue.ToArray ());
	}

    public int GetQueueLength()
    {
        return alphabetQueue.Count;
    }

    bool ValidateQueue(string answerString){

        if (GetQueueString() != answerString.Substring(0,GetQueueLength()))
        {
            return false;
        }
        else {
            return true;
        }

    }

    public void ClearQueue()
    {
        alphabetQueue.Clear();
    }
}