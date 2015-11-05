using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	//ボスの移動速度を保存.
	public float bossSpeed = 0.01f;
	//ボスの移動の幅を保存.
	public float moveWidth = 5;
	//gameObjectのrendererを読み出すための変数
	Renderer r;
	//gameObjectのAnimatorを読み出すための変数
	Animator a;
	//移動をするかしないかの状態を保存.
	bool canMove = true;
	//移動方法を設定をする変数
	bool sysMove = false;
	//1flameごとに１ずつ増加する変数
	float cnt = 1;

	void Start(){
        gameObject.transform.position = new Vector3(0, 2.5f, 0);
		r = gameObject.GetComponent<Renderer> ();
		a = gameObject.GetComponent<Animator> ();
	}

	void Update(){
		if (sysMove == true) {
			SystematicMove ();
		}
	}

	//sysMoveの状態を返す.
	public bool SysMove(){
		return sysMove;
	}

	//Cos関数を使い規則的な移動をする移動形態.
	void SystematicMove(){
		transform.position = new Vector3 (moveWidth * Mathf.Cos (cnt * bossSpeed - 90), transform.position.y);
		cnt++;
	}

	//不規則な移動をする移動形態(見えなくなる).　イメージは瞬間移動
	public void UnsystematicMoveHide(){
		Debug.Log ("In UnsystematicMoveHide()");
		gameObject.transform.position = new Vector3 (30, 30, 0);
	}

	//不規則な移動をする移動形態(見えるようになる).
	public void UnsystematicMoveShow(){
		Debug.Log ("In UnsystematicMoveShow()");
		//移動する先の座標を保存するための変数
		float rnd_x = Random.Range (-5.0f, 5.0f);
		float rnd_y = Random.Range (0.0f, 3.65f);
		Debug.Log ("rndX : " + rnd_x + ", rndY : " + rnd_y);

		//瞬間移動先に前もって移動
		gameObject.transform.position = new Vector3 (rnd_x, rnd_y, 0);
	}

	//外部からの呼び出し関数
	//移動するかしないかの状態を変更するための関数
	public void ChangeFlagMove(bool flag){
		canMove = flag;
	}

	//Animatorで使うトリガーをセットリセットする関数
	public void MySetTrigger (string name){
		a.SetTrigger (name);
	}
	public void MyResetTrigger (string name){
		a.ResetTrigger (name);
	}
}
