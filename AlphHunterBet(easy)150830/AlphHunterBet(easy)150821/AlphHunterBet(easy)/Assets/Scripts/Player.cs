using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour{

	//このコードはGame内で使わなくても問題ないことがわかりました

	Spaceship spaceship;
	Enemy enemy;
	Queue<string> queue = new Queue<string>(){};//queueクラスのインスタンスを作成
	DOOR doorref;
	Title clearTitle;
	string answer;
	private GameObject title;
	HpBarCtrl hp;
	public int answer_num = 0;
	char_count char_cnt;
	public int num;
	//public GameObject enemyPrefab;
	GameObject[] existEnemys;
	public int maxEnemy = 5;
	//private GameObject target;

	void Start (){
		Initialize ();
		existEnemys = new GameObject[maxEnemy];
	}
	//void Awake()
	//{
		//target = GameObject.Find("DOOR");
		//target.SetActive(false);
		
	//}
	void Update (){
		MovePlayer ();
	}
	//playerの移動
	void MovePlayer(){
		float x = Input.GetAxisRaw ("Horizontal");		
		float y = Input.GetAxisRaw ("Vertical");		
		Vector2 direction = new Vector2 (x, y).normalized;		
		spaceship.Move (direction);
	}

	public void Initialize(){
		spaceship = GetComponent<Spaceship> ();
		//enemy = GetComponent<Enemy> ();
//		doorref = GameObject.Find ("Title1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
		doorref = GameObject.Find ("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
		answer = GameObject.Find ("Manager1").GetComponent<SaveDoor> ().answer;
		//clearTitle = GameObject.Find ("Title").GetComponent<Title> ();
		hp = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		char_cnt = GameObject.Find ("char_count").GetComponent<char_count> ();
	}

	public void OnTriggerEnter2D (Collider2D c){
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy"){
			Enemy enemyScripts=c.GetComponent<Enemy>();//enemyを取得
			string getAlphabet=enemyScripts.alphabet;//敵の持つｱﾙﾌｧﾍﾞｯﾄを入手
			queue.Enqueue(getAlphabet);//queueに追加
			string arrayQueue=string.Concat(queue.ToArray());//現在の配列内の要素を文字列にする.
			Debug.Log ("arrayQueue:"+arrayQueue);
			spaceship.Explosion();//接触確認用の爆発の発生
			//Generate ();//いらないっす
			Destroy (c.gameObject);
			Debug.Log ("answer"+answer);


			if (arrayQueue != answer)
			{
			hp.decrease_hp();
			}else{
				num = char_cnt.decrease_cnt();
				Debug.Log (num);

				if(num == 0)
				{
					//ここの処理を考える
					//doorref.SetActive ();
					//target.SetActive(true);
					//Application.LoadLevel("base_test");
					Debug.Log (num);
					
				}

				//num = char_cnt.decrease_cnt();
	
				//if(num == 0)
				//{
					//ここの処理を考える
					//doorref.SetActive ();
					//target.SetActive(true);
					//Application.LoadLevel("base_test");
					//Debug.Log ("Clear");

				//}
				

			}
			Debug.Log ("queue.Count < answer.Length"+answer.Length);

			if(queue.Count < answer.Length){
				return;
			}
			QueueFull(c,arrayQueue);
		}
	}
	void QueueFull(Collider2D c,string arrayQueue){
		queue.Dequeue ();
		if (arrayQueue == answer)
		{
			answer_num++;
			if(answer_num > 2)
			{
			Debug.Log ("Clear");
			doorref.SetActive ();

			}
		}
		if (c.gameObject.GetComponent<Enemy> ().alphabet == "DOOR") {
			//clearTitle.SetActive ();
			char_cnt.full_cnt();
			Destroy (gameObject);
			Application.LoadLevel ("stage_clear");
		}

	}
	/*不要部分
	void Generate(){
		Debug.Log ("実行");
		for(int enemyCount = 0; enemyCount < existEnemys.Length; ++ enemyCount){
			if(existEnemys[enemyCount] == null){
				//敵を作成する
				existEnemys[enemyCount] = Instantiate(enemyPrefab,transform.position,transform.rotation) as GameObject;
				return;
			}
	//private GameObject target;
	//void Awake()
	//{
	//	target = GameObject.Find("DOOR");
	//	target.SetActive(false);

	//}
		}
	}
	*/
}