using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl: MonoBehaviour,IAlphabetQueueObserver
{
    public GameObject Slider;

    Slider _slider;
    float _hp = 1;
    public IAlphabetQueueObservable _IAlphabetQueueObservable;

    void Start () 
	{
        _IAlphabetQueueObservable.Add(this);
		_slider = Slider.GetComponent<Slider>();
	}

	void Update () 
	{
		if(_hp < 0)
		{
			Application.LoadLevel ("gameover");
		}
		
		_slider.value = _hp;
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

    }

}