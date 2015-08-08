using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour{
	
	Spaceship spaceship;
	Enemy enemy;
	Queue<string> queue = new Queue<string>(){};
	DOOR doorref;
	Title clearTitle;
	string answer;

	void Start (){
		Initialize ();
	}
	
	void Update (){
		MovePlayer ();
	}

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
		clearTitle = GameObject.Find ("Title").GetComponent<Title> ();
	}

	void OnTriggerEnter2D (Collider2D c){
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy"){
			queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
			string arrayQueue=string.Concat(queue.ToArray());
			Debug.Log ("arrayQueue:"+arrayQueue);
			spaceship.Explosion();
			Destroy (c.gameObject);

			if(queue.Count < answer.Length){
				return;
			}
			QueueFull(c,arrayQueue);
		}
	}
	void QueueFull(Collider2D c,string arrayQueue){
		queue.Dequeue ();
		if (arrayQueue == answer) {
			Debug.Log ("Clear");
			doorref.SetActive ();
		}
		if (c.gameObject.GetComponent<Enemy> ().alphabet == "DOOR") {
			clearTitle.SetActive ();
			Destroy (gameObject);
		}
	}
}
