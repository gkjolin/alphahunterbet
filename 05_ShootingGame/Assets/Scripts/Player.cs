using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

	Spaceship spaceship;
	Enemy enemy;
	Queue<string> queue = new Queue<string>(){};

	IEnumerator Start ()
	{
		spaceship = GetComponent<Spaceship> ();
		enemy = GetComponent<Enemy> ();

		while (true) {
			spaceship.Shot (transform);
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
	
		float y = Input.GetAxisRaw ("Vertical");
	
		Vector2 direction = new Vector2 (x, y).normalized;

		spaceship.Move (direction);
	}

	void OnTriggerEnter2D (Collider2D c)
	{

		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		

		if( layerName == "Bullet (Enemy)")
		{

			Destroy(c.gameObject);
		}


		if( layerName == "Bullet (Enemy)"|| layerName == "Enemy")
		{

			spaceship.Explosion();
			string arrayQueue=string.Concat(queue.ToArray());
			if(queue.Count > 2){
				if(arrayQueue == "CAT"){
					Debug.Log("Clear");
				
				}else{
				
				Debug.Log (arrayQueue.Length);
				Debug.Log (arrayQueue);
				//Debug.Log(arrayQueue[0]+arrayQueue[1]+arrayQueue[2]);
				Debug.Log("queue.Dequeue():" + queue.Dequeue());
		
					}
				}

			if (arrayQueue == "CAT") {
						if (c.gameObject.GetComponent<Enemy> ().alphabet == "!") {
								Debug.Log ("Open");
						} else {
								
						}
			}else {
				queue.Enqueue (c.gameObject.GetComponent<Enemy> ().alphabet);
			}
			Destroy (c.gameObject);
	
			
		}
	}
}