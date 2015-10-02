using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	//ボスの移動速度を保存.
	public float bossSpeed = 0.01f;
	//ボスの移動の幅を保存.
	public float moveWidth = 5;
	//移動をするかしないかの状態を保存.
	bool canMove = true;
	//1flameごとに１ずつ増加する変数
	float cnt = 1;

	void Update(){
		if (canMove == true) {
			SystematicMove ();
		}
	}

	//Cos関数を使い規則的な移動をする移動形態.
	void SystematicMove(){
		transform.position = new Vector3 (moveWidth * Mathf.Cos (cnt * bossSpeed - 90), transform.position.y);
		cnt++;
	}

	//外部からの呼び出し関数
	//移動するかしないかの状態を変更するための関数
	public void ChangeFlagMove(bool flag){
		canMove = flag;
	}
}
