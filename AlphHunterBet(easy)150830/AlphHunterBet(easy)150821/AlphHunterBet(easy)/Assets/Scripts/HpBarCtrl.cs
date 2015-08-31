using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl: MonoBehaviour {
	
	Slider _slider;
	public GameObject p1;
	public GameObject gameOverText;
	public GameObject gameover;

//high_level
	void Start () {
		// スライダーを取得する
		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		gameover = GameObject.Find ("GameOver");
		//********** 追記 **********// 
	}
	
static float _hp = 1;
	void Update () {
		// HP_down
			//_hp -= 0.1f;

		if(_hp < 0) {
			//Debug.Log ("gameover");
			//2回目以降はどうなるか
			//GameOver();
			//Debug.Log ("test");

			p1 = GameObject.Find ("Player");
			Destroy (p1);
			_hp = 1;
			Application.LoadLevel ("gameover");
			// 最大を超えたら1に戻す
			Debug.Log ("_hp = " + _hp);
			//if (Input.GetKeyDown (KeyCode.X)) {
				//gameover.SetActive (false);
				//Application.LoadLevel ("gameover");
				//Application.LoadLevel("base_test");
			//}

		}
		
		// HPゲージに値を設定
		_slider.value = _hp;
	}
	//public void GameOver ()
	//{
		// ゲームオーバー時に、タイトルを表示する
		//gameover.SetActive (true);
		//Debug.Log ("through");

	//}
	//void OnTriggerEnter2D (Collider2D c){
		
		//string layerName = LayerMask.LayerToName(c.gameObject.layer);
		//Debug.Log ("through");
		//if(layerName == "Enemy"){
			//queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
			//string arrayQueue=string.Concat(queue.ToArray());
			//Debug.Log ("arrayQueue:"+arrayQueue);
			//spaceship.Explosion();
			//Destroy (c.gameObject);
			//_hp -= 0.1f;
			//if(queue.Count < answer.Length){
				//return;
			//}
			//QueueFull(c,arrayQueue);
		//}
	public void decrease_hp()
	{
		HpBarCtrl._hp -= 0.1f;
	}
}