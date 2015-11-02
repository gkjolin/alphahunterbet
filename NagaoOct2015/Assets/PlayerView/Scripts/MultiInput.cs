using UnityEngine;
using System.Collections;

public class MultiInput : MonoBehaviour,IUserInput {

    public IUserInputContainer buttonLeft;
    public IUserInputContainer buttonRight;
    public KeyCode leftKeyCode;
    public KeyCode rightKeyCode;

    public float accel = 0.1f;
    public Vector2 maxSpeed = new Vector2(5f,0);
    public Vector2 initialSpeed = new Vector2(0.1f,0);
    Vector2 currentDirection = new Vector2(0,0);

    void Update()
    {
        Vector2 vectorSum = buttonLeft.Result.GetInputVector() + buttonRight.Result.GetInputVector()+new Vector2(Input.GetAxisRaw("Horizontal"),0);
        vectorSum = vectorSum + new Vector2((Input.GetKey(leftKeyCode) ? -1 : 0) + (Input.GetKey(rightKeyCode) ? 1 : 0), 0);
        if (vectorSum.magnitude == 0) { currentDirection = new Vector2(0,0); return; }
        currentDirection = (currentDirection.magnitude < maxSpeed.magnitude) ? currentDirection + vectorSum.normalized*Time.deltaTime * accel : currentDirection;

    }

    public Vector2 GetInputVector()
    {
        return currentDirection;
    }


}
