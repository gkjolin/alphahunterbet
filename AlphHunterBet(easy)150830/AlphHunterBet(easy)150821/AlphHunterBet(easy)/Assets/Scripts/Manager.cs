using UnityEngine;
//maga_tega;
public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	// タイトル
	private GameObject title;
	public GameObject p1;
	
	void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
	}
	
	void Update ()
	{
			//Debug.Log ("IsPlaying()" +IsPlaying ());
		
		// ゲーム中ではなく、Xキーが押されたらtrueを返す。
		if (IsPlaying()== false) {
			//GameStart ();
			title.SetActive (true);
			Application.LoadLevel("stage_clear");
		}
	}
	
	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);
		GameObject gameObjectRef = Instantiate (player, player.transform.position, player.transform.rotation) as GameObject;
		gameObjectRef.GetComponent<Player> ().Initialize ();
		Application.LoadLevel("stage_clear");
	}
	
	public void GameOver ()
	{
		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}
}