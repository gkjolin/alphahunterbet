using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour {
	private float time = 300;

	void Update ()
	{
		time -= Time.deltaTime;
		if (time < 0) {
			Application.LoadLevel("GameOver");
		}
		if (time < 0) time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
	}
}