using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {

    int stageNumber;
    Text _textRef;
	// Use this for initialization
	void Start () {
        _textRef = GameObject.Find("DisplayScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
	}
}
