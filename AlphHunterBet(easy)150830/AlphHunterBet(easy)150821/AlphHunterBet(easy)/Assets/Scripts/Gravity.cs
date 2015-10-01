using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(0f, -1f * speed));

		                          
	}
}
