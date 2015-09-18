using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstPlayer : MonoBehaviour
{
	
	Spaceship Spaceship;
	Enemy Enemy;
	Queue<string> Queue = new Queue<string>(){};//Queueクラスのインスタンス string型を格納.
	DOOR DoorRefference;
	string Answer;
	HpBarCtrl HitPoint;
	public int AnswerNumber = 0;
	char_count CharacterCount;
	public int Number;
	public static int StageNumber;
	StageControl StageLoad;

	//追加内容
	Rigidbody2D rigidBody2d;
	float speed=5;

	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		//ComonPlayer.MovePlayer(Spaceship);//Spaceshipが引数
		moveControll ();
	}

	//新規メソッド2015/9/18　移動の制御
	void moveControll(){
		float x = Input.GetAxisRaw ("Horizontal");//横取得	
		float y = Input.GetAxisRaw ("Vertical");//縦取得	
		Vector2 direction = new Vector2 (x, y).normalized;//移動の距離を算出 
		rigidBody2d.velocity = direction * speed;//speedと距離をかけて速度にする
	}
	
	public void Initialize()
	{
		//Spaceship = GetComponent<Spaceship> ();
		DoorRefference = GameObject.Find ("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
		Answer = GameObject.Find ("Manager1").GetComponent<SaveDoor> ().answer;
		HitPoint = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		CharacterCount = GameObject.Find ("char_count").GetComponent<char_count> ();//正解にぶつかって答えまであと何回かを表示
		StageLoad = GameObject.Find ("Manager1").GetComponent<StageControl> ();
		rigidBody2d=GetComponent<Rigidbody2D>();//追加内容 rigidBodyを取得する.
	}
	
	public void OnTriggerEnter2D (Collider2D c)
	{
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy")
		{
			Queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
			string arrayQueue=string.Concat(Queue.ToArray());
			//Spaceship.Explosion();

			Destroy (c.gameObject);

			if (arrayQueue != Answer)
			{
				if(c.gameObject.GetComponent<Enemy> ().alphabet != "DOOR")
					HitPoint.decrease_hp();
			}else
			{
				Number = CharacterCount.decrease_cnt();
				Debug.Log (Number);
			}

			if(Queue.Count < Answer.Length)
			{
				return;
			}
			QueueFull(c,arrayQueue);
		}
	}
	void QueueFull(Collider2D c,string arrayQueue){
		Queue.Dequeue ();
		if (arrayQueue == Answer)
		{		
			AnswerNumber++;
			if(Number < 2)
			{
				Debug.Log ("Collected the answer");
				DoorRefference.SetActive ();				
			}
		}
		if (c.gameObject.GetComponent<Enemy> ().alphabet == "DOOR") {
			CharacterCount.full_cnt();
			Destroy (gameObject);
			//次のステージをロード
			StageNumber = StageLoad.NextStage(StageNumber);//返却値はintの関数nextStageを呼び出す
		}
	}
}
