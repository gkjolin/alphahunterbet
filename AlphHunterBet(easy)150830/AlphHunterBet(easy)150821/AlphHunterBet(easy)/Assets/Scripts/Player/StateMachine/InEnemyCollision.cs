using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InEnemyCollision : StateMachineBehaviour {

	PlayerModel playerModel;
	Spaceship spaceship;
	HpBarCtrl HitPoint;
	char_count CharacterCount;
	SaveDoor saveDoor;
	IAlphabetQueueHandler alphabetRepeatHandler;

	public void Initialize(PlayerModel _player, HpBarCtrl _hpBarCtrl,SaveDoor _SaveDoor, IAlphabetQueueHandler _alphabetRepeatHandler)
    {
		if (_player == null ||  _hpBarCtrl == null ) {
			throw new ArgumentNullException ("null at EnemyCollision");
		}
		playerModel = _player;
		HitPoint = _hpBarCtrl;
		saveDoor = _SaveDoor;
        alphabetRepeatHandler = _alphabetRepeatHandler;
	}

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Collider2D c = playerModel.collisionData;
		string answer = saveDoor.answer;

        alphabetRepeatHandler.UpdateQueue(c.gameObject.GetComponent<Enemy>().alphabet,answer);

		c.gameObject.GetComponent<Spaceship>().Explosion();
		Destroy (c.gameObject);

        if (alphabetRepeatHandler.ValidateQueue(answer)) {
            AudioSource answerSE = GameObject.Find("CorrectSE").GetComponent<AudioSource>();
            answerSE.Play();
            if (alphabetRepeatHandler.GetQueueLength() == answer.Length)
            {
                saveDoor.DOOR.SetActive(true);
            }
        }
        else
        {
            AudioSource answerSE = GameObject.Find("IncorrectSE").GetComponent<AudioSource>();
            answerSE.Play();
            HitPoint.decrease_hp();
            alphabetRepeatHandler.ClearQueue();
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