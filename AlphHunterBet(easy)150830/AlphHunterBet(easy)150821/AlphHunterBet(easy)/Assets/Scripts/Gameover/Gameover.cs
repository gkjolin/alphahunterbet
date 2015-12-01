using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Input.anyKey){　//何か入力があったとき
			Application.LoadLevel("test"); //タイトルのシーンを呼ぶ
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
