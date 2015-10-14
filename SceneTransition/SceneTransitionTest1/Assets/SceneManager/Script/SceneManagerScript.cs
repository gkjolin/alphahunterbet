using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

	private static SceneManagerScript mInstance;

    public GameObject _prefab;
    public string _startScene;

    static GameObject prefab;
    static string startScene;
    static Animator animator;

    private SceneManagerScript () { // Private Constructor
		
		Debug.Log("Create SceneManager GameObject instance.");
	}
		
	public static SceneManagerScript Instance {
			
		get {
			if( mInstance == null ) {
				
				GameObject go = Instantiate(prefab,new Vector3(0,0,0),Quaternion.identity) as GameObject;
                animator = go.GetComponent<Animator>();
                mInstance = go.GetComponent<SceneManagerScript>();
				DontDestroyOnLoad(go);
				Application.LoadLevel (startScene);
			}
			return mInstance;
		}
	}
		
	void Start () {
        prefab = _prefab;
        startScene = _startScene;
        SceneManagerScript hoge = Instance;
	}
	
    public static void SetTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    
}
