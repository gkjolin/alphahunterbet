using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HelperText_Sample : MonoBehaviour {

	public Text text;//text表示を行うためにUGUIのTextを格納
	public string rightAlphabet;//正解のアルファベット

    [HideInInspector]
    public string getAlphabet;
	public enum TEXTSTATE{NONE,SUCCESS,MISS,DEFEAT,CLEAR,WAIT};
    [HideInInspector]
    public TEXTSTATE textState=TEXTSTATE.NONE;
    [HideInInspector]
    public bool corutineStart;
	
	Dictionary<TEXTSTATE,string> showText=new Dictionary<TEXTSTATE,string>();
	
	string success;
	string miss;
	string defeat;
	string clear;
	string wait;
	
	void Start () {
		SampleTextSetting ();
		TextSet ();
	}
	/// <summary>
	/// 初期テキスト
	/// </summary>
	void TextSet(){
		showText.Add (TEXTSTATE.SUCCESS,success);
		showText.Add (TEXTSTATE.MISS,miss);
		showText.Add (TEXTSTATE.DEFEAT,defeat);
		showText.Add (TEXTSTATE.WAIT,wait);
		showText.Add (TEXTSTATE.CLEAR,clear);
	}
	void SampleTextSetting(){
		success = "だな！正解だ！";
		miss="は...間違いだな...";
		defeat = "ぬわぁあああああああああああ！";
		clear = "さぁ！次なる道へ行こう！";
		wait = "はまだか...!?";
	}
	/// <summary>
	/// 正しいアルファベットか判定し、テキストを表示するようにする.
	/// </summary>
	/// <param name="alphabet">取得したAlphabet</param>
	public void AlphabetDicision(string alphabet){
		if (alphabet == rightAlphabet) {
			textState=TEXTSTATE.SUCCESS;
		} else {
			textState=TEXTSTATE.MISS;
		}
		TextChangeAndShow(textState);
	}
	/// <summary>
	/// テキストを変更＆表示. ステートを選んで実行する
	/// </summary>
	/// <param name="textState">Text state.</param>
	public void TextChangeAndShow(HelperText_Sample.TEXTSTATE textState){
		switch (textState) {

		case TEXTSTATE.SUCCESS://正解
			StopCorutineMethod();
			showText[textState]=getAlphabet+success;
			StartCoroutine("WaitTimeCorutine");
			break;
		case TEXTSTATE.MISS://ミス
			StopCorutineMethod();
			showText[textState]=getAlphabet+miss;
			StartCoroutine("WaitTimeCorutine");
			break;
		case TEXTSTATE.DEFEAT://ゲームオーバー
			showText[textState]=defeat;
			StopCorutineMethod();
			break;
		case TEXTSTATE.CLEAR://クリア
			showText[textState]=clear;
			StopCorutineMethod();
			break;
		case TEXTSTATE.WAIT://待機
			showText[TEXTSTATE.WAIT]=rightAlphabet+wait;
			corutineStart = false;
			break;
		}
		text.text=showText[textState];//テキストを表示する
	}
	/// <summary>
	/// 発生中のコルーチンを止める
	/// </summary>
	void StopCorutineMethod(){
		corutineStart = false;
		StopCoroutine("WaitTimeCorutine");
	}
	/// <summary>
	/// とってからしばらくしてからお助けキャラが喋る
	/// </summary>
	/// <returns>The time corutine.</returns>
	IEnumerator WaitTimeCorutine(){
		if (corutineStart == true)yield break;//複数回コルーチンを呼び出さないようにする.
		corutineStart = true;//コルーチン開始.
		float time = 0;
		while (time<4.5f) {
			time+=Time.deltaTime;
			yield return null;
		}
		textState = TEXTSTATE.WAIT;
		TextChangeAndShow (textState);
		yield return new WaitForSeconds (2.0f);
	}


	//----------------Demo用の表示関係--------------------------//
	//Demoで実行する以外では関係なし
	public void ShowHelperText_SUCCESS(){
		textState= TEXTSTATE.SUCCESS;
		text.text = showText [textState];
	}
	public void ShowHelperText_MISS(){
		textState = TEXTSTATE.MISS;
		text.text = showText [textState];
	}
	public void ShowHelperText_CLEAR(){
		textState = TEXTSTATE.CLEAR;
		text.text = showText [textState];
	}
	public void ShowHelperText_WAIT(){
		textState = TEXTSTATE.WAIT;
		text.text = showText [textState];
	}
	public void ShowHelperText_DEFEAT(){
		textState = TEXTSTATE.DEFEAT;
		text.text = showText [textState];
	}


}
