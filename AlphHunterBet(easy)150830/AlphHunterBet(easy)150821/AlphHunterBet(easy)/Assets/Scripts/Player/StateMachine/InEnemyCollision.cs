using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InEnemyCollision : StateMachineBehaviour {

	PlayerModel firstPlayer;
	Spaceship spaceship;
	HpBarCtrl HitPoint;
	char_count CharacterCount;
	SaveDoor saveDoor;
	IAlphabetQueueHandler alphabetQueueHandler;

	public void Initialize(PlayerModel _player, HpBarCtrl _hpBarCtrl,char_count _characterCount, SaveDoor _SaveDoor, IAlphabetQueueHandler _alphabetQueueHandler){
		if (_player == null ||  _hpBarCtrl == null || _characterCount == null) {
			throw new ArgumentNullException ("null at EnemyCollision");
		}
		firstPlayer = _player;
		HitPoint = _hpBarCtrl;
		CharacterCount = _characterCount;
		saveDoor = _SaveDoor;
		alphabetQueueHandler = _alphabetQueueHandler;
	}

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Collider2D c = firstPlayer.collisionData;
		string answer = saveDoor.answer;
		int number = firstPlayer.Number;

		alphabetQueueHandler.UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet,answer);
		c.gameObject.GetComponent<Spaceship>().Explosion();
		Destroy (c.gameObject);

        string arrayQueue = alphabetQueueHandler.GetQueueString();

        if (arrayQueue != Answer) {
			if (c.gameObject.GetComponent<Enemy> ().alphabet != "DOOR") {
				AudioSource answerSE = GameObject.Find ("IncorrectSE").GetComponent<AudioSource> ();
				answerSE.Play ();
				HitPoint.decrease_hp ();
			}
			if (CharacterCount.LeftToCollect == 0) {
				DoorReference.SetActive ();
			}
		} else {
			AudioSource answerSE = GameObject.Find ("CorrectSE").GetComponent<AudioSource> ();
			answerSE.Play ();
		}
		animator.SetTrigger("EnemyCollisionFinished");

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}