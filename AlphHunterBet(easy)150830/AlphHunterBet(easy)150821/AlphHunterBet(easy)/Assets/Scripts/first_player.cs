using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class first_player : MonoBehaviour{
	
	Spaceship spaceship;
	Enemy enemy;
	Queue<string> queue = new Queue<string>(){};
	DOOR doorref;
	Title clearTitle;
	string answer;
	private GameObject title;
	HpBarCtrl hp;
	public int answer_num = 0;
	char_count char_cnt;
	public int num;
	public Transform B;
	public Transform C;
	public Transform D;
	public Transform A;
	public int tekitou;
	public int ans = 1;


	//private GameObject target;

	void Start (){
		Initialize ();
	}
	//void Awake()
	//{
	//target = GameObject.Find("DOOR");
	//target.SetActive(false);
	
	//}
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
		//clearTitle = GameObject.Find ("Title").GetComponent<Title> ();
		hp = GameObject.Find ("HpBarCtrl").GetComponent<HpBarCtrl> ();
		char_cnt = GameObject.Find ("char_count").GetComponent<char_count> ();
	}
	
	public void OnTriggerEnter2D (Collider2D c){
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy"){
			queue.Enqueue(c.gameObject.GetComponent<Enemy>().alphabet);
			string arrayQueue=string.Concat(queue.ToArray());
			Debug.Log ("arrayQueue:"+arrayQueue);
			spaceship.Explosion();

			tekitou = Random.Range (1,3);
			if(ans%3 != 0)
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
				}
			ans++;

			Destroy (c.gameObject);
			Debug.Log ("answer"+answer);
			
			
			if (arrayQueue != answer)
			{
				if(c.gameObject.GetComponent<Enemy> ().alphabet != "DOOR")
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
				//githubtest				
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
			if(answer_num > 1)
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
	//private GameObject target;
	//void Awake()
	//{
	//	target = GameObject.Find("DOOR");
	//	target.SetActive(false);
	
	//}
}
