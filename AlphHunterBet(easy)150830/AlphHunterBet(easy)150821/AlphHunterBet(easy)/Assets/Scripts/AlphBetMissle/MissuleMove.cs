using UnityEngine;
using System.Collections;

public class MissuleMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (0, 1, 0);
	
	}

	//エネミーとのあたり判定
	bool EnemyCollision()
	{
		return true;
	}

}
