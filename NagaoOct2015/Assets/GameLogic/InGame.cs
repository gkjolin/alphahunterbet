using UnityEngine;
using System.Collections;

public class InGame : StateMachineBehaviour,IGameLogicObserver {

    Animator _animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
       GameObject.Find("GameLogic").GetComponent<GameLogic>().Add(this); 
    }

    public void UpdateObserver(GameLogic observable)
    {
        if (observable.isClear) { _animator.SetTrigger("Clear"); }
        if (observable.isDead) { _animator.SetTrigger("Dead"); }
    }

}
