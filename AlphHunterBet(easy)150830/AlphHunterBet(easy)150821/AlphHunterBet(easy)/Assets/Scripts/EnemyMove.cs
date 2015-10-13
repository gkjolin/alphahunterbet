using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	Spaceship _spaceship;
	public float speed;
	//public float _destroy;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().gravityScale = 1;
	}
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

	/*void OnWillRenderObject(){
		Debug.Log(Camera.current.name);
		if (Camera.current.name != "MainCamera") {
			Destroy (this.gameObject);
			Debug.Log("destroy");
		}

	}*/

	// Update is called once per frame
	void Update () {
		Physics2D.gravity = Vector2.up * speed;
		/*if (transform.position.y == _destroy) {
			Destroy(this.gameObject);
		}*/
	}
}
