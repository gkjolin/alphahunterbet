using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {

    static GameObject soundPlayer;
    public static SoundManagerScript mInstance;
    public static SoundDictionaryManager soundDictionaryManager;
    public static AudioSource audioSource;
	public static AudioSource BGMSource;

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

				AudioSource[] allMyAudioSources = soundPlayer.GetComponents<AudioSource>();
				audioSource = allMyAudioSources[0];
				BGMSource = allMyAudioSources[1];
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
