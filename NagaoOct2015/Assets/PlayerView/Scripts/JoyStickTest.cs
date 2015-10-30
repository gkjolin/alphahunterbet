using UnityEngine;
using System.Collections;

public class JoyStickTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.GetAxis("Horizontal"));
	
	}
}
