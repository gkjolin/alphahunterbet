using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetQueueHandler : IAlphabetQueueHandler {
	
	Queue<string> alphabetQueue = new Queue<string>{};
	
	int sizeOfQueue = 1;
	string Answer = GameObject.Find("Manager1").GetComponent<SaveDoor>().answer;
	
	public Queue<string> AlphabetQueue {
		get {
			return alphabetQueue;
		}
	}
	
	public void UpdateQueue(string newAlphabet){
		
		//キューの中身を調べる用
		//Debug.Log(alphabetQueue.Count);
		
		alphabetQueue.Enqueue(newAlphabet);
		
		if(alphabetQueue.Peek () != Answer){
			//キューが空になるまっで吐き出す
			while(alphabetQueue.Count != 0){
				alphabetQueue.Dequeue();
			}
		}
		
		if(alphabetQueue.Count > sizeOfQueue){
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