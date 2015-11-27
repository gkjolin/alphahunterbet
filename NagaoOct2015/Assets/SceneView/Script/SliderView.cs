using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderView : MonoBehaviour,IPlayerModelObserver {

    public IPlayerModelObservableContainer _IPlayerModelObservableContainer;
    public float defaultHP=1;
    Slider _slider;

    // Use this for initialization
    void Start () {
        _IPlayerModelObservableContainer.Result.Add(this);
        _slider = GetComponent<Slider>();
        _slider.value = defaultHP;
    }

    public void UpdateObserver(IPlayerModelObservable observable)
    {
        _slider.value = observable.hitPoint;
    }
}
