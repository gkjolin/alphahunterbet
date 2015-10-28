using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Inalphabet : MonoBehaviour {
	private Image _image;
	public Sprite _alphaBet;

	void Start(){
		_image = GameObject.Find ("Image").GetComponent<Image> ();
	}

	// Use this for initialization
	void Update () {
		_image.sprite = _alphaBet;
	}
}