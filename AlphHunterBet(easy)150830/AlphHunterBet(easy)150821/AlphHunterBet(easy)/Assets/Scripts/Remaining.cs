using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Remaining : MonoBehaviour {
	public Text _Text;
	public int Rum;

	void Start(){
		_Text = GameObject.Find("Remaining").GetComponent<Text>();
	}


	void Update () {
		_Text.text = "残り" + Rum;
	}
}
