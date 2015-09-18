using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour,IMove {

	float speed = 5;

	public float Speed{
		get{
			return speed;
		}
		set{
			this.speed = value;
		}
	}

	void Start(){
		Speed = speed;
	}

	// Update is called once per frame
	public void Move2D (Vector2 direction){
		GetComponent<Rigidbody2D>().velocity = direction * Speed;
	}
}
