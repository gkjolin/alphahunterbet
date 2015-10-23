using UnityEngine;
using System.Collections;

public class InDying : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        GameObject.Find("AudioSource").GetComponent<AudioSource>().clip = SoundManagerScript.soundDictionaryManager.audioClipValue("dead");
        GameObject.Find("AudioSource").GetComponent<AudioSource>().Play();

        GameObject playerView = GameObject.Find("GameLogic").GetComponent<GameLogic>().playerView;
        GameObject dyingAnimation = GameObject.Find("GameLogic").GetComponent<GameLogic>().dyingAnimation;
        Transform playerTransform = playerView.GetComponent<Transform>();
        GameObject playerCollision = GameObject.Find("GameLogic").GetComponent<GameLogic>().playerCollision;

        GameObject c = Instantiate(dyingAnimation, playerTransform.position, playerTransform.rotation) as GameObject;
        c.GetComponent<Transform>().Translate(new Vector3(0, 0, 0));
        playerCollision.GetComponent<PlayerCollision>().isActive = false;
        Destroy(GameObject.Find("PlayerView"));


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManagerScript.audioSource.Stop();

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
