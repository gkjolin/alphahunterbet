using UnityEngine;
using System.Collections;

public class PlayerInNormal : StateMachineBehaviour,IMove,IAlphabetQueueObserver
{

    float speed = 5;
    IUserInputContainer userInput;
    Animator animator;
    Rigidbody2D playerRigidbody;

	public float Speed{
		get{
			return speed;
		}
		set{
			this.speed = value;
		}
	}

	public void Initialize (IUserInputContainer _userInput,Rigidbody2D _rigidbody, IAlphabetQueueObservable observable, Animator _animator){
		userInput = _userInput;
		Speed = speed;
		playerRigidbody = _rigidbody;
        observable.Add(this);
        animator = _animator;
    }

    public void UpdateAlphabetQueueObserver(IAlphabetQueueObservable observable)
    {
        if (observable.isRight) animator.SetTrigger("Right");
        else animator.SetTrigger("Wrong");
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
        playerRigidbody.velocity = new Vector2(direction.x, 0);
    }

}
