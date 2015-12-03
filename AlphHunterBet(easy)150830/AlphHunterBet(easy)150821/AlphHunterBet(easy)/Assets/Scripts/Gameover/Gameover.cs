using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        { //何か入力があったとき
            Debug.Log("test");
            //Application.LoadLevel("test"); //タイトルのシーンを呼ぶ
        }

    }
}
