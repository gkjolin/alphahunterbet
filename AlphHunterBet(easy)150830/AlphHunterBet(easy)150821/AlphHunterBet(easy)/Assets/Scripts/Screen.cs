using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {
	public GameObject A;
	// Use this for initialization
	void Start () {
		Instantiate(A, this.transform.position, this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
