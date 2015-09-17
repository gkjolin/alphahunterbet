using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCollision : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		FirstPlayer firstPlayer = GameObject.Find ("Player").GetComponent<FirstPlayer> ();
		Spaceship spaceship = GameObject.Find ("Player").GetComponent<Spaceship> ();

		Collider2D c = firstPlayer.collisionData;
		Queue<string> queue = firstPlayer.Queue;
		string Answer = firstPlayer.Answer;
		int Number = firstPlayer.Number;
		HpBarCtrl HitPoint = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		char_count CharacterCount = GameObject.Find ("char_count").GetComponent<char_count> ();;

		queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
		string arrayQueue=string.Concat(queue.ToArray());

		spaceship.Explosion();
		
		Destroy (c.gameObject);
		
		if (arrayQueue != Answer)
		{
			if(c.gameObject.GetComponent<Enemy> ().alphabet != "DOOR")
				HitPoint.decrease_hp();
		}else
		{
			Number = CharacterCount.decrease_cnt();
			Debug.Log (Number);
		}
		
		if(queue.Count < Answer.Length)
		{
			return;
		}

		queue.Dequeue ();

		if (arrayQueue == Answer)
		{		
			firstPlayer.AnswerNumber++;
			if(Number < 2)
			{
				Debug.Log ("Collected the answer");
				DOOR DoorRefference = GameObject.Find ("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
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
