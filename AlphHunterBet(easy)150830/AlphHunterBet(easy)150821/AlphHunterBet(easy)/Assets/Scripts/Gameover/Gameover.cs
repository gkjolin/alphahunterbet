using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		background = GetConponent<GUITexture>().texture; //画像を表示
		audio.PlayOneShot(failed);　// 音を鳴らす
		if(Input.anykey){　//何か入力があったとき
			Application.Load("scene"); //タイトルのシーンを呼ぶ
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
