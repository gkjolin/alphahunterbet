using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

	private static SceneManagerScript mInstance;
	
	private SceneManagerScript () { // Private Constructor
		
		Debug.Log("Create SceneManager GameObject instance.");
	}
		
	public static SceneManagerScript Instance {
			
		get {
			
			if( mInstance == null ) {
				
				GameObject go = new GameObject("SceneManager");
				mInstance = go.AddComponent<SceneManagerScript>();
			}
			
			return mInstance;
		}
	}
		
	void Start () {
		Debug.Log("Start");
	}
	
	void Update () {
		
		Debug.Log("Update");
	}
}
