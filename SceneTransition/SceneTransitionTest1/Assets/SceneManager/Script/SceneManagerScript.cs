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
				DontDestroyOnLoad(mInstance);
				Application.LoadLevel ("Start");
			}
			return mInstance;
		}
	}
		
	void Start () {
		Debug.Log("Start");
		SceneManagerScript hoge = SceneManagerScript.Instance;
	}
	
	void Update () {

		Debug.Log("Update");
	}
}
