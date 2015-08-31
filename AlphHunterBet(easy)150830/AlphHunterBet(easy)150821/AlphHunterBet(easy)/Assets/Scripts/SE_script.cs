using UnityEngine;
using System.Collections;

public class SE_script : MonoBehaviour {

	
	public AudioClip audioClip;
	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	public void se_button(){
		audioSource.Play ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
