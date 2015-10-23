using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {
	Text text;
	ParticleSystem particle;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		particle = GetComponent<ParticleSystem> ();
		text.color = particle.startColor;
	}
	
	// Update is called once per frame
	void Update () {
	//	text.color = particle.startColor;
	}
}
