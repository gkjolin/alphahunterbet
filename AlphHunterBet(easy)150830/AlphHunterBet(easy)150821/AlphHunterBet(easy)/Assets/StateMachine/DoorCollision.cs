using UnityEngine;
using System.Collections;

public class DoorCollision : StateMachineBehaviour {
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		char_count CharacterCount = GameObject.Find ("char_count").GetComponent<char_count> ();
		CharacterCount.full_cnt();
		//Destroy (GameObject.Find ("Player"));
		int stageNumber = animator.GetInteger("StageNumber");
		StageControl StageLoad=GameObject.Find ("Manager1").GetComponent<StageControl> ();
		animator.SetInteger("StageNumber",StageLoad.NextStage(stageNumber));
	}
	
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//	}
	
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
