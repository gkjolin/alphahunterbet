using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SecondPlayer : MonoBehaviour
{
	
	Spaceship Spaceship;
	Enemy Enemy;
	Queue<string> Queue = new Queue<string>(){};
	DOOR DoorRefference;
	Title ClearTitle;
	string Answer;
	private GameObject Title;
	HpBarCtrl HitPoint;
	public int AnswerNumber = 0;
	char_count CharacterCount;
	public int Number;
	public static int StageNumber = 1;
	StageControl StageLoad;
	
	
	
	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		MovePlayer ();
	}
	
	void MovePlayer()
	{
		float x = Input.GetAxisRaw ("Horizontal");		
		float y = Input.GetAxisRaw ("Vertical");		
		Vector2 Direction = new Vector2 (x, y).normalized;		
		Spaceship.Move (Direction);
	}
	
	public void Initialize()
	{
		Spaceship = GetComponent<Spaceship> ();
		DoorRefference = GameObject.Find ("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
		Answer = GameObject.Find ("Manager1").GetComponent<SaveDoor> ().answer;
		HitPoint = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		CharacterCount = GameObject.Find ("char_count").GetComponent<char_count> ();
		StageLoad = GameObject.Find ("Manager1").GetComponent<StageControl> ();
	}
	
	public void OnTriggerEnter2D (Collider2D c)
	{
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy")
		{
			Queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
			string arrayQueue=string.Concat(Queue.ToArray());
			Debug.Log ("arrayQueue:"+arrayQueue);
			Spaceship.Explosion();
			//RandomProcessing
			//tekitou = Random.Range (1,3);
			/*if(ans%3 != 0)
			{
			if(tekitou == 1)
			{
			//add
			float addXPos = Random.Range(-6.0f, 6.0f);
			float addYPos = Random.Range(-6.0f, 6.0f);
			Vector2 spawnPos = new Vector2 (addXPos, addYPos);
			Instantiate(B, spawnPos, Quaternion.identity);
			}

			if(tekitou == 2)
			{
				
				float addXPos = Random.Range(-6.0f, 6.0f);
				float addYPos = Random.Range(-6.0f, 6.0f);
				Vector2 spawnPos = new Vector2 (addXPos, addYPos);
				Instantiate(C, spawnPos, Quaternion.identity);
			}
			if(tekitou == 3)
			{
				float addXPos = Random.Range(-6.0f, 6.0f);
				float addYPos = Random.Range(-6.0f, 6.0f);
				Vector2 spawnPos = new Vector2 (addXPos, addYPos);
				Instantiate(D, spawnPos, Quaternion.identity);
			}
			}else
			{
					float addXPos = Random.Range(-6.0f, 6.0f);
					float addYPos = Random.Range(-6.0f, 6.0f);
					Vector2 spawnPos = new Vector2 (addXPos, addYPos);
					Instantiate(A, spawnPos, Quaternion.identity);
				}*/
			//ans++;
			
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
			Debug.Log ("queue.Count < answer.Length"+Answer.Length);
			
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
			if(Number < 1)
			{
				Debug.Log ("Clear");
				DoorRefference.SetActive ();
				
			}
		}
		if (c.gameObject.GetComponent<Enemy> ().alphabet == "DOOR") {
			CharacterCount.full_cnt();
			Destroy (gameObject);
			//次のステージをロード
			StageNumber = StageLoad.NextStage(StageNumber);
		}
	}
}
