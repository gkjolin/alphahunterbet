using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstPlayer : MonoBehaviour
{
	Animator animator;

	public string Answer;
	public int AnswerNumber = 0;
	public int Number;
	public static int StageNumber;

	public Collider2D collisionData;

	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		//ComonPlayer.MovePlayer(Spaceship);
	}
	
	public void Initialize()
	{
		animator = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	
	public void OnTriggerEnter2D (Collider2D c)
	{

		collisionData = c;

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
