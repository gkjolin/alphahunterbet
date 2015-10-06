using UnityEngine;
using System.Collections;

public class SEManager: MonoBehaviour {

	IAlphabetQueueHandler alphabetQueueHandler;
	PlayerModel firstPlayer;
	string Answer;
	string arrayQueue;

	void Start(){
	}

	void Update () {
		if (arrayQueue != Answer) {
			AudioSource answerSE = GameObject.Find ("IncorrectSE").GetComponent<AudioSource> ();
			answerSE.Play ();
		} else {
			AudioSource answerSE = GameObject.Find ("CorrectSE").GetComponent<AudioSource> ();
			answerSE.Play ();
		}
	}
}
