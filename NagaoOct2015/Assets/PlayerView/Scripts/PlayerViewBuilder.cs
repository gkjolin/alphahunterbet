using System;
using UnityEngine;
using System.Collections;

public class PlayerViewBuilder : MonoBehaviour
{
    public IUserInputContainer PlayerInput;
    public IAlphabetQueueObservableContainer _IAlphabetQueueObservableContainer;

    // Use this for initialization
    void Start()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
        Rigidbody2D rigidbody2d = GameObject.Find("Player").GetComponent<Rigidbody2D>();        

        gameObject.GetComponent<Animator>().GetBehaviour<PlayerInNormal>().Initialize(PlayerInput, rigidbody2d, _IAlphabetQueueObservableContainer.Result,playerAnimator);
    }

}
