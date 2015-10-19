using UnityEngine;
using System.Collections;

public class MissuleMove : MonoBehaviour {
	public int explodeLevel = 10;//爆発規模
	public GameObject target = null;//ターゲット
	public float moveSpeed = 1;//速度
	public int timeCount = 50;//時限

	private bool isCollision = false;

	private Detonator exp;
	private SpriteRenderer render;
	private AudioSource sound;
	private PolygonCollider2D missuleCollider;

	// Use this for initialization
	void Start ()
	{
		exp = gameObject.GetComponent<Detonator> ();
		render = gameObject.GetComponent<SpriteRenderer> ();
		sound = gameObject.GetComponent<AudioSource> ();
		missuleCollider = gameObject.GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update (){
		if (isCollision || timeCount <= 0) {
			if (explodeLevel > 0) {
				MissuleExplode ();
			}
		} else {
			gameObject.transform.Translate (0, 0.1f * moveSpeed, 0);
			timeCount--;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == target.layer) {
			render.enabled = false;
			sound.PlayOneShot (sound.clip);	
			isCollision = true;
		}
	}

	private void MissuleExplode(){
		exp.MissuleExplode();
		explodeLevel--;
	}

}
