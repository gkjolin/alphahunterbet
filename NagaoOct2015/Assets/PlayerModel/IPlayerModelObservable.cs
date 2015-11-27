using System;
using UnityEngine;
using System.Collections;

public interface IPlayerModelObservable {

    int leftToCollect { get; set; }
    float hitPoint { get; set; }

    void Add(IPlayerModelObserver observer);

}

[Serializable]
public class IPlayerModelObservableContainer : IUnifiedContainer<IPlayerModelObservable> { }