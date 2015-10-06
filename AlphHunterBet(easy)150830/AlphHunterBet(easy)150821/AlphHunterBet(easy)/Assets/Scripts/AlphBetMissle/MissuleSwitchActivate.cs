using UnityEngine;
using System.Collections;

/*MissuleSwitchActivate:
オブジェクトmissuleSwitchの活性・非活性の制御をプレイヤーのステートマシン情報を用いて行う
実行にプレイヤーのAnimatorコンポーネントの情報とそのステートマシンの固有名詞を用いる
*/
public class MissuleSwitchActivate : MonoBehaviour {
	public string stateName_collisionWithDoor = "CollisionWithDoor";
	public GameObject player;
	public GameObject missuleSwitch;

	private GameObject AlphMissuleSwitch ;//ミサイル発射スイッチ名
	private Animator player_in_Animator;//プレイヤーのアニメーター
	private string currentState;//現在のステートのハッシュ値
	private static string hash_collisionWithDoor;//ステートのハッシュ値 
	
	// Use this for initialization
	void Start ()
	{
		//hash_collisionWithDoor = Animator.StringToHash(stateName_collisionWithDoor);
		player_in_Animator = player.GetComponent<Animator> ();
		missuleSwitch.SetActive (false);//スイッチ非活性化
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isCollisionWithDoor () ) 
		{
			Debug.Log("MissuleSwitch_Activate");
			missuleSwitch.SetActive(true);
		}
	}

	bool isCollisionWithDoor()
	{
		//↓のisName(引数：比較するステート名)が今のステートと引数の名称とを比較してbool値返す
		return player_in_Animator.GetCurrentAnimatorStateInfo (0).IsName (stateName_collisionWithDoor);
	}

}
