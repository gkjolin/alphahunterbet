using UnityEngine;
using System.Collections;

public class MissuleMove : MonoBehaviour {
	private Detonator exp;
	int count = 30;

	// Use this for initialization
	void Start () {
		exp = gameObject.GetComponent<Detonator> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (0, 0.1f, 0);
	if (count <= 0) {
			exp.MissuleExplode();

		}
		count--;
	}

	//エネミーとのあたり判定
	bool EnemyCollision()
	{
		return true;
	}

}
