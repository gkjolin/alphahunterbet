using UnityEngine;
using System.Collections;

/*MissuleSwitchActivate:
オブジェクトmissuleSwitchの活性・非活性の制御をプレイヤーのステートマシン情報を用いて行う
実行にプレイヤーのAnimatorコンポーネントの情報とそのステートマシンの固有名詞を用いる
*/
public class MissuleSwitch: MonoBehaviour {
	public GameObject AlphbetSwitchUI; 
	
	private UsingScript_to_AlphbetSwitch usingScript;
	private static bool isLunch = true;//misslelunchは一度だけ実行(テスト用のため常にture)

	private string stateName;
	private GameObject player = null;
	private Animator player_in_Animator = null;//プレイヤーのアニメーター
	private GameObject lunchObject = null;//発射するオブジェクト

	// Use this for initialization
	void Start ()
	{
		usingScript = AlphbetSwitchUI.GetComponent<UsingScript_to_AlphbetSwitch>();
		stateName = usingScript.stateName_collisionWithDoor;
		player = usingScript.player;
		player_in_Animator = usingScript.player.GetComponent<Animator> ();
		lunchObject = usingScript.lunchObject;
	//	gameObject.SetActive (false);//スイッチ非活性化
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isCollisionWithDoor () ) 
		{
			Debug.Log("MissuleSwitch_Activate");
			gameObject.SetActive(true);
		}
	}

	bool isCollisionWithDoor()
	{
		//↓のisName(引数：比較するステート名)が今のステートと引数の名称とを比較してbool値返す
		return player_in_Animator.GetCurrentAnimatorStateInfo (0).IsName (stateName);
	}
	
	private bool isMissuleObject()
	{
		if ( !lunchObject ) {
			Debug.Log ("発射オブジェクトが見つかりませんでした");
			return false;
		}
		return true;
	}

	public void missuleLunch()
	{
		if ( !isLunch )
		{
			return;
		}
		if ( !isMissuleObject () ) 
		{
			return;
		}
		GameObject.Instantiate (lunchObject, player.transform.position, new Quaternion (0, 0, 0, 0));
		//isLunch = false;
	}


}
