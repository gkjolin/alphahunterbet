using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetQueueHandler : IAlphabetQueueHandler {

	Queue<string> alphabetQueue = new Queue<string>{};

	int sizeOfQueue = 1;

	public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
	}

	public void UpdateQueue(string newAlphabet){
		alphabetQueue.Enqueue(newAlphabet);
		if (alphabetQueue.Count > sizeOfQueue) {
			alphabetQueue.Dequeue ();
		}
	}

	public string GetQueueString(){
		return string.Concat (alphabetQueue.ToArray ());
	}

	public bool ValidateQueue(string answerString,int repeats){
		return false;
	}

}
