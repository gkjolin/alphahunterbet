using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissuleLunch : MonoBehaviour 
{
	public GameObject lunchObject = null;//発射するオブジェクト
	public GameObject player = null;
	private static bool isLunch = true;//misslelunchは一度だけ実行

	// Use this for initialization
	void Start () 
	{
		lunchObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void missuleLunch()
	{
		if (!isLunch)
		{
			return;
		}
		if (!isMissuleObject () ) 
		{
			return;
		}
		missuleInitialize ();
		isLunch = false;
	}

	private bool isMissuleObject()
	{
		if (!lunchObject) {
			Debug.Log ("発射オブジェクトが見つかりませんでした");
			return false;
		}
		return true;
	}

	private void missuleInitialize()
	{
		Debug.Log("misulleLunch!!!");
		lunchObject.transform.position = player.transform.position;
		lunchObject.SetActive (true);
		//GameObject.Instantiate(lunchObject, player.transform.position, new Quaternion(0,0,0,0));
	}

}
