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

<<<<<<< HEAD
			num = 3;
		}
		GetComponent<Text> ().text = (num).ToString ();
	}
			public int decrease_cnt()
			{
		AudioSource answerSE = GameObject.Find ("CorrectSE").GetComponent<AudioSource> ();
		answerSE.Play ();
			return char_count.num -= 1;
		}
	public void full_cnt()
	{
		char_count.num = 3;
=======
	void Update () {
		GetComponent<Text> ().text = (LeftToCollect).ToString ();
>>>>>>> cc739c6313f223cd381f6c880a2f8996d6679d21
	}
}
