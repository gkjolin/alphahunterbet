using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Inalphabet : MonoBehaviour {
	private Image _image;
	public Sprite _alphaBet;

	// Use this for initialization
	void Start () {
		_image = GameObject.Find ("Image").GetComponent<Image> ();
		_image.sprite = _alphaBet;
	}
}