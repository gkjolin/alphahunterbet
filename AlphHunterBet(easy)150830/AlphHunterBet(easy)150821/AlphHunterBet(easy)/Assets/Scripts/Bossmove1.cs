using UnityEngine;
using System.Collections;

public class Bossmove1 : MonoBehaviour {
	
	// Spaceshipコンポーネント
	Spaceship spaceship;
	
	void Start ()
	{
		
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
		
		// スタート時左に移動
		spaceship.Move (transform.right * -1);
	}
}