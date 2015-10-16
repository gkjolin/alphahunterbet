using System;
using UnityEngine;
using System.Collections;

public class PlayerViewBuilder : MonoBehaviour
{
    public IUserInputContainer PlayerInput;

    // Use this for initialization
    void Start()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
        Rigidbody2D rigidbody2d = gameObject.GetComponent<Rigidbody2D>();

        gameObject.GetComponent<Animator>().GetBehaviour<MovePlayerInNormal>().Initialize(PlayerInput, rigidbody2d);
    }

}
