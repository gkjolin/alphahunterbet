using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class char_count : MonoBehaviour, IAlphabetQueueObserver
{

    public int numberToCollect = 3;
    public int LeftToCollect
    {
        get
        {
            return numberToCollect - _IAlphabetQueueObservable.queueString.Length;
        }
    }

    public IAlphabetQueueObservable _IAlphabetQueueObservable;

    void Start()
    {
        _IAlphabetQueueObservable.Add(this);
    }

    public void UpdateAlphabetQueueObserver(IAlphabetQueueObservable observable)
    {
        GetComponent<Text>().text = (LeftToCollect).ToString();
    }
}
