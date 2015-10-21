using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {
	public GameObject Alphabet;
	public Text txt;
	public int Num;
	// Use this for initialization
	void Start () {
		Instantiate(Alphabet, this.transform.position, this.transform.rotation);
		txt.text = "上のアルファベットを" + Num + "個集めてね"; 
	}
	
	// Update is called once per frame
	void Update () {

	}
}
