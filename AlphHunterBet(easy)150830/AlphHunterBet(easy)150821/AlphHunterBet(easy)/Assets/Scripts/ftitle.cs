using UnityEngine;
using System.Collections;

public class ftitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				// mouce clicked
				if (Input.GetMouseButtonDown(0)){
						// scene load
						Application.LoadLevel("stage_2");
					
				}
		
	}
}
