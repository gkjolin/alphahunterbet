using System;
using UnityEngine;
using System.Collections;

public class EnemyCollisionInitializer : MonoBehaviour {

	// Use this for initialization

	void Start () {

		GameObject player = GameObject.Find ("Player");
		//FirstPlayer firstPlayer = player.GetComponent<FirstPlayer> ();
		FirstPlayer firstPlayer = player.GetComponent<FirstPlayerChild> () as FirstPlayer;
		Spaceship spaceship = player.GetComponent<Spaceship> ();
		HpBarCtrl hpBarCtrl = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		char_count characterCount = GameObject.Find ("char_count").GetComponent<char_count> ();;
		DOOR DoorRefference = GameObject.Find ("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
		IAlphabetQueueHandler alphabetQueueHandler = new AlphabetQueueHandler ();
		Animator playerAnimator = player.GetComponent<Animator> ();

		playerAnimator.GetBehaviour<EnemyCollision> ().Initialize (firstPlayer, spaceship, hpBarCtrl,characterCount,DoorRefference, alphabetQueueHandler);

	}
	
}
