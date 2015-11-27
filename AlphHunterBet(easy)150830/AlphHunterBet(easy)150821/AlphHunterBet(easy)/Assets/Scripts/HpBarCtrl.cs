using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl: MonoBehaviour 
{
	//Sliderクラスを保存するための変数
	Slider _slider;
	//各GameObjectを保存するための変数
	//ここで宣言されていた"public GameObject gameOverText;"は未使用のため削除
	public GameObject p1;				//Player
	public GameObject gameover;			//GameOver
	//自機のHP残量を保存する変数
	static float _hp = 1;

	//high_level
	void Start () 
	{
		//"Slider"GameObjectの"Slider"Componentを取得
		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		//"GameOver"GameObjectを取得
		gameover = GameObject.Find ("GameOver");
		//"Player"GameObjectを取得
		p1 = GameObject.Find ("Player");
	}

	void Update () 
	{
		// HP_down : _hp -= 0.1f;

		if(_hp < 0)
		{
			//Find関数はUpdate内で実行する必要がないため,Start内へ移動

			//HPが0となったため,自機を破壊
			Destroy (p1);

			//HPの初期化は不要だったため削除

			//gameoverSceneを呼び出し
			Application.LoadLevel ("gameover");
			//現在の_hpの値をコンソール上に表示
			Debug.Log ("_hp = " + _hp);
		}
		
		// HPゲージに値を設定
		_slider.value = _hp;
	}

	//GameOverメソッド,OnTriggerEnter２Dメソッドは必要ないようなので削除

	//他クラスからの呼び出しメソッド
	//自クラスの_hpの値を呼び出されるたびに-0.1fづつ減少させる.
	public void decrease_hp()
	{
		//このクラスの_hpを-0.1f減少させる.
		_hp -= 0.1f;
	}
}