using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour 
{
	//Bossが撃つ間隔を設定する変数.
	public float waitShotTime = 10;
	//Bossが撃つ球を保存するための変数.とりあえず3つ.
	public GameObject[] arrayAlphabet = new GameObject[26];
	//アルファベットの種類の数を保存すする変数
	public int cntAlphabet = 26;
	//呼び出し変数
	BossMove bm;
	Animator a;
	//移動回数を保存する変数
	public int rndM;
	//GameObject

	void LoadComponents(){
		//読み込み
		bm = gameObject.GetComponent<BossMove> ();
		a = gameObject.GetComponent<Animator> ();
	}

	IEnumerator Start()
	{
		LoadComponents ();
		//ゲームが始まってすぐに発射されるのを防ぐために待ち時間設定.
		yield return new WaitForSeconds (0.5f);

		if (bm.SysMove () == true) {
			//SystematicMove
			Debug.Log ("MoveRele : SystematicMove");
			while (true) {
				//発射前に一時停止
				//移動しないようにBossMove内のcanMoveをfalseに.
				bm.ChangeFlagMove (false);
				yield return new WaitForSeconds (1.0f);

				//アルファベットの投下
				DropAlphabet ();

				//発射ののちに再び動き出す.
				yield return new WaitForSeconds (1.0f);
				bm.ChangeFlagMove (true);

				//発射したあとすぐに発射しないように待ち時間を設定.
				//待ち時間は"waitShotTime"で設定可能.
				yield return new WaitForSeconds (waitShotTime - 2.5f);
			}
		} else {
			//UnsistematicMove
			Debug.Log ("MoveRele : UnsystematicMove");
			a.SetTrigger ("inUnsystematic");
		}
	}

	//アルファベットを投下するための関数
	//移動回数は最大５回
	public void DropAlphabet(){
		//randomの返却値を保存する変数.
		//発射するものを無作為に決定するため,ランダム関数を使用.
		int rnd = Random.Range (0, cntAlphabet);
		Debug.Log ("DArnd : " + rnd);

		Instantiate (arrayAlphabet [rnd], transform.position, transform.rotation);
	}

	//何回移動するかを決定する関数
	public void Random1to5 (){
		rndM = Random.Range (1, 6);
		Debug.Log ("rndM : " + rndM);
	}

	//rndMを減少させるための関数
	public void CountDownM(){
		rndM--;
		Debug.Log ("rndM(CountDownM) : " + rndM);
		if (rndM == 0) 
		{
			a.SetTrigger ("toShot");
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(10,10,100,50),"rndM : " + rndM);
	}
}