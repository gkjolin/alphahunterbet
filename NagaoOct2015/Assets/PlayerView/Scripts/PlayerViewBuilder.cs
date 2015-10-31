using System;
using UnityEngine;
using System.Collections;

public class PlayerViewBuilder : MonoBehaviour
{
    public IUserInputContainer PlayerInput;
    public Rigidbody2D playerRigidbody;
    public IAlphabetQueueObservableContainer _IAlphabetQueueObservableContainer;

    // Use this for initialization
    void Start()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
 
        gameObject.GetComponent<Animator>().GetBehaviour<PlayerInNormal>().Initialize(PlayerInput, playerRigidbody, _IAlphabetQueueObservableContainer.Result,playerAnimator);
    }

}
