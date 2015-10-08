using UnityEngine;
using System.Collections;

public class MissleLunch : MonoBehaviour 
{
	public GameObject lunchAlphbet = null;//発射するオブジェクト

	private static bool isLunch = true;//misslelunchは一度だけ実行

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void missleLunch()
	{
		if (!isLunch)
		{
			return;
		}
		if (!isMissleObject () ) 
		{
			return;
		}
		GameObject.Instantiate(lunchAlphbet,new Vector3(0,0,0), new Quaternion(0,0,0,0));
		isLunch = false;
	}

	private bool isMissleObject()
	{
		if (!lunchAlphbet) {
			Debug.Log ("発射オブジェクトが見つかりませんでした");
			return false;
		}
		return true;
	}

}
