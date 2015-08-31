using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {
	public GameObject BeePrefab;
	
	// Use this for initialization
	void Start () {
		for (int i=0 ; i<1 ; ++i) {
			Instantiate(BeePrefab,new Vector3(1,-2,0),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}