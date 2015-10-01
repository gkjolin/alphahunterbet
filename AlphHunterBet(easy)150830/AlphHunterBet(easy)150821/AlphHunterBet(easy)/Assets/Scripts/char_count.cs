using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class char_count : MonoBehaviour {

	char_count cnt;
	public int numberToCollect = 3;
    public int LeftToCollect
    {
        get
        {
            Debug.Log(numberToCollect - _AlphabetQueueHandler.GetQueueLength());
            return numberToCollect - _AlphabetQueueHandler.GetQueueLength();
        }
    } 

    IAlphabetQueueHandler _AlphabetQueueHandler;

    public void Initialize(IAlphabetQueueHandler _AlphabetQueueHandler)
    {
        this._AlphabetQueueHandler = _AlphabetQueueHandler;
    }

	void Update () {
		GetComponent<Text> ().text = (LeftToCollect).ToString ();
	}
}
