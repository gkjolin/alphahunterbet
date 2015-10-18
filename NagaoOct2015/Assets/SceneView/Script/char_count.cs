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
            return numberToCollect - _IAlphabetQueueObservableContainer.Result.queueString.Length;
        }
    }

    public IAlphabetQueueObservableContainer _IAlphabetQueueObservableContainer;

    void Start()
    {
        _IAlphabetQueueObservableContainer.Result.Add(this);
    }

    public void UpdateAlphabetQueueObserver(IAlphabetQueueObservable observable)
    {
        GetComponent<Text>().text = (LeftToCollect).ToString();
    }
}
