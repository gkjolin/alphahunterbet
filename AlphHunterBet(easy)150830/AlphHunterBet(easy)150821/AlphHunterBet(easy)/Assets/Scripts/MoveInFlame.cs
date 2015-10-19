using UnityEngine;
using System.Collections;

public class MoveInFlame :MonoBehaviour ,IMove{
	Vector2 player_point;/*playerの座標*/
	Rigidbody2D rigidbody2d;
	float speed = 5;
	public float Speed{
		get{
			return speed;
		}
		set{
			this.speed = value;
		}
	}
	public void Move2D (Vector2 direction){
        rigidbody2d.velocity = direction * Speed;
	}
	void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	void Update(){
		Clamp ();
	}
	void Clamp()
	{
		player_point = transform.position;
		Vector2 left_limit = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); /*画面左端*/
		Vector2 right_limit = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)); /*画面右端*/

		player_point.x = Mathf.Clamp (player_point.x, left_limit.x, right_limit.x);/*画面の枠より左右の座標にしない*/
		transform.position = player_point;
	}

}
