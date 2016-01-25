using UnityEngine;
using System.Collections;

public class Meteo: MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;

	public int Des = 5;

	void Start ()
	{
		
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
		
		// ローカル座標のY軸のマイナス方向に移動する
		spaceship.Move (transform.up * -1);



		//Des秒後にオブジェクトを削除
		Destroy(gameObject, Des);
	}
}