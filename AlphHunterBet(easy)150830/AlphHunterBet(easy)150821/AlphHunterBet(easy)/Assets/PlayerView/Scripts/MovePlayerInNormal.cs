using UnityEngine;
using System.Collections;

public class MovePlayerInNormal : StateMachineBehaviour,IMove {
	
	Rigidbody2D rigidbody2d;
	float speed = 5;
    IUserInputContainer userInput;

	public float Speed{
		get{
			return speed;
		}
		set{
			this.speed = value;
		}
	}

	public void Initialize (IUserInputContainer _userInput,Rigidbody2D _rigidbody2d){
		userInput = _userInput;
		Speed = speed;
		rigidbody2d = _rigidbody2d;
	}
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Move2D(userInput.Result.GetInputVector());
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

	public void Move2D (Vector2 direction){
		rigidbody2d.velocity = direction * Speed;
	}

}
