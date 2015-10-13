using UnityEngine;
using System.Collections;

public class MissuleMove : MonoBehaviour {
	public int explodeLevel = 10;
	public int timeCount = 30;
	public float moveSpeed = 1;
	private bool isExplode = false;
	private Detonator exp;
	private SpriteRenderer render;
	private AudioSource sound;


	// Use this for initialization
	void Start ()
	{
		exp = gameObject.GetComponent<Detonator> ();
		render = gameObject.GetComponent<SpriteRenderer> ();
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.Translate (0, 0.1f * moveSpeed, 0);
	if (timeCount <= 0 && explodeLevel > 0) 
		{
			exp.MissuleExplode();
			explodeLevel--;
			if( ! isExplode )
			{
				render.enabled = false;
				sound.PlayOneShot(sound.clip);	
				isExplode = true;
			}
		}
		timeCount--;
	}

	//エネミーとのあたり判定
	bool EnemyCollision()
	{
		return true;
	}

}
