using UnityEngine;
using System.Collections;

public class InGame : StateMachineBehaviour,IGameLogicObserver {

    public IGameLogicObservableContainer _IGameLogicObservableContainer;
    public Animator animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _IGameLogicObservableContainer.Result.Add(this); 
                           
    }

    public void UpdateObserver(IGameLogicObservable observable)
    {
        if (observable.isClear) { animator.SetTrigger("Clear"); }
        if (observable.isDead) { animator.SetTrigger("Dead"); }
    }

}
