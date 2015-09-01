using UnityEngine;
using System.Collections;

public static class ComonPlayer {


	public static void MovePlayer(Spaceship Spaceship)
	{
		float x = Input.GetAxisRaw ("Horizontal");		
		float y = Input.GetAxisRaw ("Vertical");		
		Vector2 Direction = new Vector2 (x, y).normalized;		
		Spaceship.Move (Direction);
	}


}
