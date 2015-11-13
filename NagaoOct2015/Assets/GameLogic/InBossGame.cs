using UnityEngine;
using System.Collections;

public class InBossGame : StateMachineBehaviour,IGameLogicObserver {

    Animator _animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
       GameObject.Find("GameLogic").GetComponent<GameLogic>().Add(this); 
		SoundManagerScript.BGMSource.clip = SoundManagerScript.soundDictionaryManager.audioClipValue("BossMusic");
		SoundManagerScript.BGMSource.volume = 0.3f;
		SoundManagerScript.BGMSource.Play();		
    }

    public void UpdateObserver(GameLogic observable)
    {
        if (observable.isClear) { _animator.SetTrigger("Clear"); }
        if (observable.isDead == true) { _animator.SetTrigger("Dead"); }
    }

}
