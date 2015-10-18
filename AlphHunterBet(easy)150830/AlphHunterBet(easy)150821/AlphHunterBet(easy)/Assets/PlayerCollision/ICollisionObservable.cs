using UnityEngine;
using System.Collections;

public interface ICollisionObservable {

    void Add(ICollisionObserver observer);

}
