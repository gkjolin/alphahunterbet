using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetRepeatQueue : MonoBehaviour, ICollisionObserver, IAlphabetQueueObservable, IAlphabetQueueHandler {
	
	Queue<string> alphabetQueue = new Queue<string>{};
    public string answer;
    public ICollisionObservable _ICollisionObservable;

    List<IAlphabetQueueObserver> observers = new List<IAlphabetQueueObserver>();

    public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
	}

    public bool isRight
    {
        get { return ValidateQueue(answer); }
    }
    public string queueString
    {
        get { return GetQueueString(); }
    }

    void Start()
    {
        _ICollisionObservable.Add(this);
    }

    public void Add(IAlphabetQueueObserver observer)
    {
        observers.Add(observer);
    }

    public void UpdateCollisionObserver(Collider2D c)
    {
        UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet, GetComponent<PlayerModel>().answer);
        observers.ForEach(arg => arg.UpdateAlphabetQueueObserver(this));
        if (!isRight) ClearQueue();
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

    public bool ValidateQueue(string answerString){

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