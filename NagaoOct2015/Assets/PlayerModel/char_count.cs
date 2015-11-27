using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class char_count : MonoBehaviour, IAlphabetQueueObserver
{

    public int numberToCollect;

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
        numberToCollect= GetComponent<AlphabetRepeatQueue>().answer.Length;
        _IAlphabetQueueObservableContainer.Result.Add(this);
    }

    public void UpdateAlphabetQueueObserver(IAlphabetQueueObservable observable)
    {
        PlayerModel r = GetComponent<PlayerModel>();
        r.leftToCollect = numberToCollect-_IAlphabetQueueObservableContainer.Result.queueString.Length;
    }
}
