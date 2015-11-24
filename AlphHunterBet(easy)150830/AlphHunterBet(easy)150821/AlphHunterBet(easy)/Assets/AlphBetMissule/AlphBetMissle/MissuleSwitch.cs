using UnityEngine;
using System.Collections;


public class MissuleSwitch: MonoBehaviour {
	public GameObject AlphbetSwitchUI; 
	
	private ObjectData_to_AlphbetSwitch usingScript;
	private GameObject player = null;//このオブジェクトからミサイルを発射する
	private GameObject lunchObject = null;//発射するオブジェクト
	private static bool isLunch = true;//misslelunchは一度だけ実行(テスト用のため常にture)

	// Use this for initialization
	void Start ()
	{
		usingScript = AlphbetSwitchUI.GetComponent<ObjectData_to_AlphbetSwitch>();
		player = usingScript.player;
		lunchObject = usingScript.lunchObject;
	//	gameObject.SetActive (false);//スイッチ非活性化
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	private bool isLunchObject()
	{
		if ( !lunchObject ) {
			Debug.Log ("発射オブジェクトが見つかりませんでした");
			return false;
		}
		return true;
	}

	public void MissuleLunch()
	{
		if ( !isLunch ){return;}
		if (!isLunchObject ()) {return;}
		Debug.Log("lunch");
		GameObject.Instantiate (lunchObject, player.transform.position, new Quaternion (0, 0, 0, 0));
		//isLunch = false;
	}


}
