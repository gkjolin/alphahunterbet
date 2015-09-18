using UnityEngine;
using System.Collections;

public class DOOR : MonoBehaviour {
	//リファクタリングの結果,Spaceshipへの参照が不要になったため”Spaceship spaceship"を削除
	public string alphabet;
	Player player;

	//球を撃つ処理関係の関数などは不要であると判断したため削除
	//そのためyeild処理が不要になったためvoid型に変更
	//リファクタリングの結果,Spaceshipへの参照が不要になったため削除
	void Start (){
		//このクラスを持つGameObjectを隠す(非表示化)
		gameObject.SetActive (false);
	}

	//void OnTriggerEnter2D(Collider2D c)が,ゲームに影響を及ぼしていないことが分かったため削除

	//何に使用されているかわからないので触っていない
	public void SetActive(){
		gameObject.SetActive (true);
		Debug.Log ("Set active");
	}
}