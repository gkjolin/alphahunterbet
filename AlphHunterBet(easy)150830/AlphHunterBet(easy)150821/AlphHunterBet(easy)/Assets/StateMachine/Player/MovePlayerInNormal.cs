using UnityEngine;
using System.Collections;

public class MovePlayerInNormal : StateMachineBehaviour {
	
	Rigidbody2D rigidbody2d;
	float speed = 5;
	IUserInput userInput;
    IMove move;


	public float Speed{
		get{
			return speed;
		}
		set{
			this.speed = value;
		}
	}

	public void Initialize (IUserInput _userInput,Rigidbody2D _rigidbody2d, IMove _move){
		userInput = _userInput;
		Speed = speed;
		rigidbody2d = _rigidbody2d;
        move = _move;
	}
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		move.Move2D(userInput.GetInputVector());
	}

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
