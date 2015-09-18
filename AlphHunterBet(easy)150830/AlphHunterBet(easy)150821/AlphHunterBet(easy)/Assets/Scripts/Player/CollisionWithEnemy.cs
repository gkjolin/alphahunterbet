using UnityEngine;
using System.Collections;

public class CollisionWithEnemy : MonoBehaviour {


	Collider2D collisionData;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GameObject.Find ("Player").GetComponent<Animator> ();

	}
	
	public void OnTriggerEnter2D (Collider2D c)
	{
		
		collisionData = c;
		GetComponent<PlayerModel> ().collisionData = c;
		
		if (c.gameObject.GetComponent<Enemy> ().alphabet == "DOOR") {
			animator.SetTrigger ("CollisionWithDoor");
			return;
		}
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if(layerName == "Enemy")
		{
			animator.SetTrigger ("CollisionWithEnemy");
			
		}
	}

}
