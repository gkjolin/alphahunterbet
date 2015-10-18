using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetRepeatQueue : MonoBehaviour, ICollisionObserver, IAlphabetQueueHandler {
	
	Queue<string> alphabetQueue = new Queue<string>{};

    public ICollisionObservable _ICollisionObservable;
		
	public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
	}

    void Start()
    {
        _ICollisionObservable.Add(this);
    }

    public void UpdateCollisionObserver(Collider2D c)
    {
        UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet, GetComponent<PlayerModel>().answer);
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
        Debug.Log(GetQueueString());
        Debug.Log(answerString.Substring(0, GetQueueLength()));

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