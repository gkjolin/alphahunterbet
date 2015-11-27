using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAlphabetQueueHandler  {

	Queue<string> AlphabetQueue {get;}

	void UpdateQueue(string newAlphabet);
	string GetQueueString();
	bool ValidateQueue(string answerString,int repeats);

}
