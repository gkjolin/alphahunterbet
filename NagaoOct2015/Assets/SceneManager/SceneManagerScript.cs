using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {


    public GameObject _prefab;
    public string _startScene;

    static GameObject prefab;
    static string startScene;
    static SceneManagerScript mInstance;
    public static Animator animator;

    private SceneManagerScript () { // Private Constructor
		
		Debug.Log("Create SceneManager GameObject instance.");
	}
		
	public static SceneManagerScript Instance {
			
		get {
			if( mInstance == null ) {
				
				GameObject go = Instantiate(prefab,new Vector3(0,0,0),Quaternion.identity) as GameObject;
                mInstance = go.GetComponent<SceneManagerScript>();
                animator = go.GetComponent<Animator>();
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
