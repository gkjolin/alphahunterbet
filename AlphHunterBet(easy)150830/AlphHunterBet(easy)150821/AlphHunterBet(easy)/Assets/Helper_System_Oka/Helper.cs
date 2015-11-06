using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Helper : MonoBehaviour {
	
	Color hideColor=new Color(45,45,45,255);
	Color showColor=Color.white;
	public GameObject helperIcon;//inspectorから設定
	string text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//アニメーターでお助けキャラの表示を制御すると変な値をとるので要調整.
	//無理ならコードで制御する.

	//dictionaryで制御するのがいいかもしれない
	//デモ用のボタンに設定 正誤判定のtriggerは後日調べておく
	public void succcessText(){
		text = "成功";
		Debug.Log (text);
	}
	public void missText(){
		text = "ミスった";
		Debug.Log (text);
	}
	public void clearText(){
		text="ステージクリア";
		Debug.Log (text);
	}
	public void waitText(){
		text="待ってるよ";
		Debug.Log (text);
	}
}
