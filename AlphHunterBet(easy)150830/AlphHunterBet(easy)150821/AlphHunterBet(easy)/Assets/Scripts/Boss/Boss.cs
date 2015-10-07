using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	//Bossが撃つ間隔を設定する変数.
	public float waitShotTime = 10;
	//Bossが撃つ球を保存するための変数.とりあえず3つ.
	public GameObject alphabet01;
	public GameObject alphabet02;
	public GameObject alphabet03;
	//アルファベットの種類の数を保存すする変数
	public int cntAlphabet = 3;
	//BossMove呼び出し変数
	BossMove bm;

	void LoadComponents(){
		//読み込み
		bm = gameObject.GetComponent<BossMove> ();
	}

	IEnumerator Start()
	{
		LoadComponents ();
		//randomの返却値を保存する変数.
		int rnd;
		Debug.Log (bm);

		while (true) {
			//ゲームが始まってすぐに発射されるのを防ぐために待ち時間設定.
			yield return new WaitForSeconds (0.5f);

			//発射するものを無作為に決定するため,ランダム関数を使用.
			rnd = Random.Range (1, cntAlphabet  + 1);

			//発射前に一時停止
			//移動しないようにBossMove内のcanMoveをfalseに.
			bm.ChangeFlagMove(false);
			yield return new WaitForSeconds (1.0f);

			//発射するオブジェクトを決定.
			//インスタンス化
			if(rnd == 1){
				Instantiate (alphabet01, transform.position, transform.rotation);
			}
			if(rnd == 2){
				Instantiate (alphabet02, transform.position, transform.rotation);
			}
			if(rnd == 3){
				Instantiate (alphabet03, transform.position, transform.rotation);
			}

			//発射ののちに再び動き出す.
			yield return new WaitForSeconds (1.0f);
			bm.ChangeFlagMove(true);

			//発射したあとすぐに発射しないように待ち時間を設定.
			//待ち時間は"waitShotTime"で設定可能.
			yield return new WaitForSeconds (waitShotTime - 2.5f);
		}
	}
}