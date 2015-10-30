using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UGUIEventTriger))] //こちらでPointerDown、PointerUpイベントの設定をしておくこと

public class EventTest : MonoBehaviour {

    // Use this for initialization
    public Transform playerTransform;
    public float accel=0.1f;
    public float maxSpeed = 5f;
    public float initialSpeed=0.1f;
    public KeyCode assignKeyCode;
    float currentDirection = 0;

    public void OnDown()
    {
        currentDirection = initialSpeed;
    }

    public void OnUp()
    {
        currentDirection = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(assignKeyCode)) currentDirection = initialSpeed;
        if(Input.GetKeyUp(assignKeyCode)) currentDirection = 0;

        currentDirection = (currentDirection!=0 && Mathf.Pow(currentDirection,2) < Mathf.Pow(maxSpeed, 2)) ? currentDirection + Time.deltaTime * accel : currentDirection;

        playerTransform.Translate(new Vector3(currentDirection, 0, 0));
    }



}
