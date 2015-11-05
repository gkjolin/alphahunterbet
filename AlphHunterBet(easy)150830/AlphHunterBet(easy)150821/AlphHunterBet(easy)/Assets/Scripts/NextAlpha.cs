using UnityEngine;
using System.Collections;

public class NextAlpha : MonoBehaviour {
	public GameObject Alphabet;


	public void Next(GameObject _alphabet){
		Instantiate(_alphabet, this.transform.position, this.transform.rotation);
	}
}
