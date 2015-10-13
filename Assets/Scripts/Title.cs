using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetActive(){
		gameObject.SetActive (true);
	}
	public void SetACtive(){
		if (Input.GetKeyDown (KeyCode.X)) {
			gameObject.SetActive (false);

		}
	}

}
