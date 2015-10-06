using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InEnemyCollision : StateMachineBehaviour {

	PlayerModel firstPlayer;
	Spaceship spaceship;
	HpBarCtrl HitPoint;
	char_count CharacterCount;
	DOOR DoorRefference;
	IAlphabetQueueHandler alphabetQueueHandler;

	public void Initialize(PlayerModel _player, HpBarCtrl _hpBarCtrl,char_count _characterCount, DOOR _DOOR, IAlphabetQueueHandler _alphabetQueueHandler){
		if (_player == null ||  _hpBarCtrl == null || _characterCount == null) {
			throw new ArgumentNullException ("null at EnemyCollision");
		}
		firstPlayer = _player;
		HitPoint = _hpBarCtrl;
		CharacterCount = _characterCount;
		DoorRefference = _DOOR;
		alphabetQueueHandler = _alphabetQueueHandler;
	}

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Collider2D c = firstPlayer.collisionData;
		string Answer = firstPlayer.Answer;
		int Number = firstPlayer.Number;

		alphabetQueueHandler.UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet);
		string arrayQueue=alphabetQueueHandler.GetQueueString();

		c.gameObject.GetComponent<Spaceship>().Explosion();
		Destroy (c.gameObject);
		
		if (arrayQueue != Answer){
			if(c.gameObject.GetComponent<Enemy> ().alphabet != "DOOR"){
				AudioSource answerSE = GameObject.Find ("IncorrectSE").GetComponent<AudioSource> ();
				answerSE.Play();
				HitPoint.decrease_hp();
			}
		}else{
			Number = CharacterCount.decrease_cnt();
		}
		
		if (arrayQueue == Answer){		
			firstPlayer.AnswerNumber++;

			if(Number < 2){
				DoorRefference.SetActive ();
			}
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
