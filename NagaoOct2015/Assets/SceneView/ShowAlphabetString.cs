using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAlphabetString : MonoBehaviour {

    AlphabetRepeatQueue AlphabetQueueString;
    Text Text;
	// Use this for initialization
	void Start () {
        AlphabetQueueString = GameObject.Find("PlayerModel").GetComponent<AlphabetRepeatQueue>();
        Text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Text.text = AlphabetQueueString.answer;
    }
}
