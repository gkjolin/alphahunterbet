using UnityEngine;
using System.Collections;

public class ftitle : MonoBehaviour {

	// Update is called once per frame
	void Update () {
				// mouce clicked
			if (Input.GetMouseButtonDown(0)){
            // scene load
            Debug.Log("mouse down");
                SceneManagerScript.SetTrigger("Explain");					
			}
		
	}
}
