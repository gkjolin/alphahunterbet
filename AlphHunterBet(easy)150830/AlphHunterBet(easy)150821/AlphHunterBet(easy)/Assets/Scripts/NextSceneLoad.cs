using UnityEngine;
using System.Collections;

public class NextSceneLoad : MonoBehaviour {

	public static int NextNumber = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void NextScineLoadMethod()
	{
		NextNumber++;
		Application.LoadLevel ("stage_" + NextNumber);
	}
}
