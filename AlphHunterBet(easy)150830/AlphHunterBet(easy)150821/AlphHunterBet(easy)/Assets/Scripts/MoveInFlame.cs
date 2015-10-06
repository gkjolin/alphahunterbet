using UnityEngine;
using System.Collections;

public class MoveInFlame :MonoBehaviour ,IMove{
	Vector2 player_point;/*playerの座標*/
	void start(){
	}
	void update(){
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
