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
	//見えるようになる見えなくなる速度を設定する変数
	public float canSeeSpeed = 0.01f;
	//見えなくなってからの時間を設定する変数
	public float cantSeeTime = 1.5f;
	//見えるようになってからの時間を設定する変数
	public float canSeeTime = 1.5f;

	void Start(){
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
/*	問題点(1)	
		//徐々に見えなくなっていく演出
		while(r.material.color.a != 0){
			r.material.color -= new Color(0, 0, 0, canSeeSpeed);
		}
*/
		//gameObjectの座標をゲーム画面外へ移動(予期しない動作を防ぐ);
		gameObject.transform.position = new Vector3 (30, 30, 0);
	}

	//不規則な移動をする移動形態(見えるようになる).
	public void UnsystematicMoveShow(){
		//移動する先の座標を保存するための変数
		float rnd_x = Random.Range (-5.0f, 5.0f);
		float rnd_y = Random.Range (0.0f, 3.65f);
		Debug.Log ("rndX : " + rnd_x + ", rndY : " + rnd_y);

		//瞬間移動先に前もって移動
		gameObject.transform.position = new Vector3 (rnd_x, rnd_y, 0);
/*	問題点(2)
		//徐々に見えてくる演出
		while (r.material.color.a != 1) {
			r.material.color += new Color(0, 0, 0, canSeeSpeed);
		}
*/
	}

	//外部からの呼び出し関数
	//移動するかしないかの状態を変更するための関数
	public void ChangeFlagMove(bool flag){
		canMove = flag;
	}

	public void MySetTrigger (string name){
		a.SetTrigger (name);
	}

	public void MyResetTrigger (string name){
		a.ResetTrigger (name);
	}

}
