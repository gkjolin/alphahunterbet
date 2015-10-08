using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour {
	private float time = 300;
	//public ballScript BallScript;
	//********** 追記 **********// 
	public GameObject exchangeButton;
	public GameObject gameOverText;
	public GameObject p1;
	private GameObject title;
	public GameObject player;
	public bool test;
	Title gvTltle;

	void Start () {
		//********** 追記 **********// 
//		gameOverText.SetActive(false);
		//********** 追記 **********// 
		GetComponent<Text>().text = ((int)time).ToString();
	}
	
	void Update ()
	{
		time -= Time.deltaTime;
		//********** 追記 **********// 
		if (time < 0) {
			StartCoroutine("GameOver");
		}
		//********** 追記 **********// 
		if (time < 0) time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
		// ゲーム中ではなく、Xキーが押されたらtrueを返す。
	}
	//********** 追記 **********// 
	IEnumerator GameOver () {
		gameOverText.SetActive(true);
		Debug.Log ("gameover");
		p1 = GameObject.Find ("Player");
		Destroy (p1);

		if (Input.GetKeyDown (KeyCode.X)) {
			Application.LoadLevel("base_test");
		}

		exchangeButton.GetComponent<Button>().interactable = false;
		//BallScript.isPlaying = false;
		yield return new WaitForSeconds(2.0f);
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("title");

		}
	}


	

	
	public void GameOver1 ()
	{
		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}



	//********** 追記 **********// 
}