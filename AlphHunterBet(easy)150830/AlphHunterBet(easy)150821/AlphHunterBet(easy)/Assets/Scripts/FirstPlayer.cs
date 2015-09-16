using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstPlayer : MonoBehaviour
{
	
	Spaceship Spaceship;
	Enemy Enemy;
	Queue<string> Queue = new Queue<string>(){};
	DOOR DoorRefference;
	string Answer;
	HpBarCtrl HitPoint;
	public int AnswerNumber = 0;
	char_count CharacterCount;
	public int Number;
	public static int StageNumber;
	StageControl StageLoad;

	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		ComonPlayer.MovePlayer(Spaceship);
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
			Spaceship.Explosion();

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
			StageNumber = StageLoad.NextStage(StageNumber);
		}
	}
}
