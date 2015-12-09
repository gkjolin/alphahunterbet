using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HelperText_Sample : MonoBehaviour {

	public Text text;//text表示を行うためにUGUIのTextを格納
	public string rightAlphabet;//正解のアルファベット

    [HideInInspector]
    public string getAlphabet;
	public enum TEXTSTATE{NONE,SUCCESS,MISS,DEFEAT,CLEAR,WAIT,START};
    [HideInInspector]
    public TEXTSTATE textState=TEXTSTATE.NONE;
    [HideInInspector]
    public bool corutineStart;
	public bool show;
	public Animator animator;
	
	Dictionary<TEXTSTATE,string> showText=new Dictionary<TEXTSTATE,string>();
	
	string success;
	string miss;
	string defeat;
	string clear;
	string wait;
	string start;
	
	void Start () {
		SampleTextSetting ();
		TextSet ();
		TextChangeAndShow (TEXTSTATE.START);
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
		showText.Add (TEXTSTATE.START,start);
	}
	void SampleTextSetting(){
		success = "だな！正解だ！";
		miss="は...間違いだな...";
		defeat = "ぬわぁあああああああああああ！";
		clear = "さぁ！次なる道へ行こう！";
		wait = "はまだか...!?";
		start = "頑張っていってみよう！";
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
	/// 正解のアルファベットを設定する.最初はなにも設定されてないのでこれで設定する.
	/// </summary>
	/// <param name="nextRightAlphabet">次正解のアルファベット</param>
	public void RightAlphabetChange(string nextRightAlphabet){
		rightAlphabet = nextRightAlphabet;
	}

	/// <summary>
	/// クリアのテキストを表示する.
	/// </summary>
	public void ClearTextSet(){
		TextChangeAndShow (TEXTSTATE.CLEAR);
	}
	/// <summary>
	/// ゲームオーバーのテキストを表示する.
	/// </summary>
	public void DefeatTextSet(){
		TextChangeAndShow (TEXTSTATE.DEFEAT);
	}

	/// <summary>
	/// テキストを変更＆表示. ステートを選んで実行する
	/// </summary>
	/// <param name="textState">Text state.</param>
	void TextChangeAndShow(HelperText_Sample.TEXTSTATE textState){
		ShowHelper ();
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
			StartCoroutine("WaitTimeCorutine");
			break;
		}
		text.text=showText[textState];//テキストを表示する
	}
	//start
	void ShowHelper(){
		Debug.Log ("表示するぞ");
		StartCoroutine ("ShowAndStop");
	}
	IEnumerator ShowAndStop(){
		if (show==true)yield break;
		show = true;
		animator.SetBool ("Show",show);
		float time = 0f;
		while(time<7f){
			time+=Time.deltaTime;
			Debug.Log("表示してます");
			yield return null;
		}
		show = false;
		animator.SetBool ("Show",show);
		Debug.Log ("止まるよ");
		yield return new WaitForSeconds (1.0f);
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
		while (time<15f) {
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
		TextChangeAndShow (TEXTSTATE.CLEAR);
	}
	public void ShowHelperText_WAIT(){
		textState = TEXTSTATE.WAIT;
		text.text = showText [textState];
	}
	public void ShowHelperText_DEFEAT(){
		textState = TEXTSTATE.DEFEAT;
		text.text = showText [textState];
		TextChangeAndShow (TEXTSTATE.DEFEAT);
	}


}
