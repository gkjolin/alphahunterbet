using UnityEngine;
using System.Collections;

public interface IAlphabetQueueObservable {

    bool isRight  { get; }
    string queueString { get; }
    
    void Add(IAlphabetQueueObserver observer);

}
