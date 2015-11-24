using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour{

	public Vector3 GetInputVector (){
		float x = Input.GetAxisRaw ("Horizontal");		
		float y = Input.GetAxisRaw ("Vertical");		
		return new Vector3 ((x*0.1f), (y*0.1f),0f);		
	}

	void Update(){
		gameObject.transform.Translate (GetInputVector ());
	}

}