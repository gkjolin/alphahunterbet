using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	
	Spaceship _spaceship;
	public float speed;
	public float _destroy;

	// Use this for initialization
	void Start () {
	
	}
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	/*void Update () {
		Physics2D.gravity = Vector2.up * speed;
		if (transform.position.y == _destroy) {
			Destroy(this.gameObject);
		}
	}*/
}
