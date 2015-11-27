using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InBossDying : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        List<GameObject> bosses = GameObject.FindObjectsOfType<GameObject>().Where(s => s.name == "Boss").ToList<GameObject>();

        foreach(GameObject g in bosses)
        {
            Destroy(g);
        }

        SoundManagerScript.BGMSource.Stop();
        SoundManagerScript.audioSource.clip = SoundManagerScript.soundDictionaryManager.audioClipValue("BossDying");
		SoundManagerScript.audioSource.volume = 0.3f;
		SoundManagerScript.audioSource.Play();		
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
