using UnityEngine;
using System.Collections;

public class BuildSceneManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);	
	}
}
