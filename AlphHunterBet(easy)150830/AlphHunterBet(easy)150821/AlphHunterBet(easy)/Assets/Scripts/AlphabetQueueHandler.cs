using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphabetQueueHandler : IAlphabetQueueHandler {
	
	Queue<string> alphabetQueue = new Queue<string>{};
	
	int sizeOfQueue = 3;
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


        if (newAlphabet != Answer){
			//キューが空になるまっで吐き出す
                alphabetQueue.Clear();
		}
		
		if(alphabetQueue.Count > sizeOfQueue){
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

    public bool ValidateQueue(string answerString,int repeats){
		return false;
	}

}