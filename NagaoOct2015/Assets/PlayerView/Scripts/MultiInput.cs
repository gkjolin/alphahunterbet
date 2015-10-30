using UnityEngine;
using System.Collections;

public class MultiInput : MonoBehaviour,IUserInput {

    public IUserInputContainer buttonLeft;
    public IUserInputContainer buttonRight;
    public KeyCode leftKeyCode;
    public KeyCode rightKeyCode;

    public float accel = 0.1f;
    public float maxSpeed = 5f;
    public float initialSpeed = 0.1f;
    Vector2 currentDirection = new Vector2(0,0);

    void Update()
    {
        Vector2 vectorSum = -buttonLeft.Result.GetInputVector() + buttonRight.Result.GetInputVector();
        vectorSum = vectorSum + new Vector2((Input.GetKeyDown(leftKeyCode) ? -1 : 0) + (Input.GetKeyDown(rightKeyCode) ? 1 : 0), 0);

        if (vectorSum.magnitude == 0) { currentDirection = 0; return; }

        currentDirection = (currentDirection != 0 && Mathf.Pow(currentDirection, 2) < Mathf.Pow(maxSpeed, 2)) ? currentDirection + Time.deltaTime * accel : currentDirection;


    }

    public Vector2 GetInputVector()
    {
        playerTransform.Translate(new Vector3(currentDirection, 0, 0));



        return new Vector2(currentDirection, 0);
    }


}
