using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl: MonoBehaviour,IAlphabetQueueObserver
{
    float _hp = 1;
    public IAlphabetQueueObservableContainer _IAlphabetQueueObservableContainer;

    void Start () 
	{
        _IAlphabetQueueObservableContainer.Result.Add(this);
    }

    //自クラスの_hpの値を呼び出されるたびに-0.1fづつ減少させる.
    public void decrease_hp()
	{
		//このクラスの_hpを-0.1f減少させる.
		_hp -= 0.1f;
	}

    public void UpdateAlphabetQueueObserver(IAlphabetQueueObservable observable)
    {
        if (!observable.isRight)  decrease_hp();
        GetComponent<PlayerModel>().hitPoint = _hp;
    }
}