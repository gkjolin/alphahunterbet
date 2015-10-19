using UnityEngine;
using System.Collections;

public class TapInput : MonoBehaviour,IUserInput {
	public float speed = 2;
	bool push =false;

	public void PushDown_left(){
		push=true;
		speed=-2;
	}

	public void PushUp_left(){
		push = false;
	}

	public void PushDown_right(){
		push=true;
		speed=2;
	}

	public void PushUp_right(){
		push = false;
	}

	void Updata(){
		GetInputVector ();
	}

	public Vector2 GetInputVector (){
    	if (push) {
			Vector2 direction = new Vector2 (1.0f, 0).normalized;
			return GetComponent<Rigidbody2D> ().velocity = direction * speed;
		} else {
			return new Vector2 (0, 0);
		}
	}
}
