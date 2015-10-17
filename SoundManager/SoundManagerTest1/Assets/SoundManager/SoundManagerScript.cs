using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {

    static GameObject soundPlayer;
    public static SoundManagerScript mInstance;
    public static SoundDictionaryManager soundDictionaryManager;
    public static AudioSource audioSource;

    private SoundManagerScript () { // Private Constructor	
        Debug.Log("Create SoundManager GameObject instance.");
	}
		
	public static SoundManagerScript Instance {
			
		get {
			if( mInstance == null ) {
                GameObject go = new GameObject("SoundManager");
                mInstance = go.AddComponent<SoundManagerScript>();
                soundPlayer = GameObject.Find("SoundPlayer");
                soundDictionaryManager = soundPlayer.GetComponent<SoundDictionaryManager>();
                audioSource = soundPlayer.GetComponent<AudioSource>();
                DontDestroyOnLoad(go);
                DontDestroyOnLoad(soundPlayer);
            }
            return mInstance;
		}
	}

    void Start()
    {
        SoundManagerScript hoge = Instance;
    }

}
