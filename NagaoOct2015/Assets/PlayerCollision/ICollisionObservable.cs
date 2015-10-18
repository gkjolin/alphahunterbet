using System;
using UnityEngine;
using System.Collections;

public interface ICollisionObservable {    
    void Add(ICollisionObserver observer);
    void Remove(ICollisionObserver observer);
}

[Serializable]
public class ICollisionObservableContainer : IUnifiedContainer<ICollisionObservable> { }