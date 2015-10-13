using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAlphabetQueueHandler  {

	Queue<string> AlphabetQueue {get;}

	void UpdateQueue(string newAlphabet,string answerString);
    void ClearQueue();
    string GetQueueString();
	bool ValidateQueue(string answerString);    
    int GetQueueLength();

}
