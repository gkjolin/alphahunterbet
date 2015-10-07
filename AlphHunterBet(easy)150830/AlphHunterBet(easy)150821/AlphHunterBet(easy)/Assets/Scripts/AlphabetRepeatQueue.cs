using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetRepeatQueue : IAlphabetQueueHandler {
	
	Queue<string> alphabetQueue = new Queue<string>{};
		
	public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
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

        if (newAlphabet != Answer)
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