using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class char_count : MonoBehaviour {

	public int numberToCollect = 3;
    public int LeftToCollect
    {
        get
        {
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
