using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {
	public Text _text;
	public int life;

	// Update is called once per frame
	void Update () {
		_text.text = "のこり" + life;
	}
}
