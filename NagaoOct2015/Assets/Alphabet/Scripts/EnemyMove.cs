using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour,ICollisionObserver {
	
	Spaceship _spaceship;
	public float speed;

    public ICollisionObservableContainer _ICollisionObservableContainer;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().gravityScale = 1;
        _ICollisionObservableContainer.Result.Add(this);
    }
	void OnBecameInvisible() {
        _ICollisionObservableContainer.Result.Remove(this);
        GetComponent<Enemy>().isAlive = false;
		Destroy (gameObject);
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
	}

    public void UpdateCollisionObserver(Collider2D c)
    {

    }
	
}
