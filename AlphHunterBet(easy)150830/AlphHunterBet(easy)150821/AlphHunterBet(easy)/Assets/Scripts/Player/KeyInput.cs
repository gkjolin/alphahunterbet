using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour,IUserInput {

	public Vector2 GetInputVector (){
		float x = Input.GetAxisRaw ("Horizontal");		
		float y = Input.GetAxisRaw ("Vertical");		
		return new Vector2 (x, y).normalized;		
	}

}
