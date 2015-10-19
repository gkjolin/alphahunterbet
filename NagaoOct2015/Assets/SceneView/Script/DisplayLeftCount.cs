using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayLeftCount : MonoBehaviour,IPlayerModelObserver {

    public IPlayerModelObservableContainer _IPlayerModelObservableContainer;

    // Use this for initialization
    void Start () {
        _IPlayerModelObservableContainer.Result.Add(this);
	}
	
	public void UpdateObserver (IPlayerModelObservable observable) {
        GetComponent<Text>().text = (observable.leftToCollect).ToString();
    }
}
