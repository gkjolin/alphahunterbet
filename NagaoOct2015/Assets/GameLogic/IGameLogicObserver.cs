using UnityEngine;
using System.Collections;

public interface IGameLogicObserver {

    void UpdateObserver(IGameLogicObservable observable);

}
