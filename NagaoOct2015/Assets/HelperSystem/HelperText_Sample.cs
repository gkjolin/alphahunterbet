using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HelperText_Sample : MonoBehaviour {

	public Text text;
	public string rightAlphabet;

    [HideInInspector]
    public string getAlphabet;
	public enum TEXTSTATE{NONE,SUCCESS,MISS,DEFEAT,CLEAR,WAIT};
    [HideInInspector]
    public TEXTSTATE textState=TEXTSTATE.NONE;
    [HideInInspector]
    public bool corutineStart;
	
	Dictionary<TEXTSTATE,string> showText=new Dictionary<TEXTSTATE,string>();

	//sample text
	string success;
	string miss;
	string defeat;
	string clear;
	string wait;

	// Use this for initialization
	void Start () {
		sampleTextSetting ();
		textSet ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void textSet(){
		showText.Add (TEXTSTATE.SUCCESS,success);
		showText.Add (TEXTSTATE.MISS,miss);
		showText.Add (TEXTSTATE.DEFEAT,defeat);
		showText.Add (TEXTSTATE.WAIT,wait);
		showText.Add (TEXTSTATE.CLEAR,clear);
	}
	void sampleTextSetting(){
		success = "だな！正解だ！";
		miss="は...間違いだな...";
		defeat = "ぬわぁあああああああああああ！";
		clear = "さぁ！次なる道へ行こう！";
		wait = "はまだか...!?";
	}

	public void alphabetDicision(string alphabet){
		if (alphabet == rightAlphabet) {
			showText[TEXTSTATE.SUCCESS]=getAlphabet+success;
			textState=TEXTSTATE.SUCCESS;
		} else {
			showText[TEXTSTATE.MISS]=getAlphabet+miss;
			textState=TEXTSTATE.MISS;
		}
		text.text=showText[textState];
		StartCoroutine("WaitTimeCorutine");
	}

	IEnumerator WaitTimeCorutine(){
		if (corutineStart == true)yield break;
		corutineStart = true;
		float time = 0;
		Debug.Log ("corutine start");
		while (time<4.5f) {
			Debug.Log ("wait now");
			time+=Time.deltaTime;
			yield return null;
		}
		showText[TEXTSTATE.WAIT]=rightAlphabet+wait;
		textState = TEXTSTATE.WAIT;
		text.text=showText[textState];
		corutineStart = false;
		yield return new WaitForSeconds (2.0f);
	}

	//
	public void showHelperText_SUCCESS(){
		textState= TEXTSTATE.SUCCESS;
		text.text = showText [textState];
	}
	public void showHelperText_MISS(){
		textState = TEXTSTATE.MISS;
		text.text = showText [textState];
	}
	public void showHelperText_CLEAR(){
		textState = TEXTSTATE.CLEAR;
		text.text = showText [textState];
	}
	public void showHelperText_WAIT(){
		textState = TEXTSTATE.WAIT;
		text.text = showText [textState];
	}
	public void showHelperText_DEFEAT(){
		textState = TEXTSTATE.DEFEAT;
		text.text = showText [textState];
	}


}
