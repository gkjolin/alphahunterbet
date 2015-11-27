using System;
using UnityEngine;
using System.Collections;

public interface IGameLogicObservable  {

    bool isClear { get; set; }
    bool isDead { get; set; }

    void Add(IGameLogicObserver observer);

}

[Serializable]
public class IGameLogicObservableContainer : IUnifiedContainer<IGameLogicObservable> { }
