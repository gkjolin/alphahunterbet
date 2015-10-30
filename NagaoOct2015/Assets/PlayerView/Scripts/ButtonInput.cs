using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UGUIEventTriger))] //こちらでPointerDown、PointerUpイベントの設定をしておくこと
public class ButtonInput : MonoBehaviour,IUserInput {

    public float direction = 1;
    public float currentDirection;

    public void OnDown()
    {
        currentDirection = direction;
    }

    public void OnUp()
    {
        currentDirection = 0;
    }

    public Vector2 GetInputVector()
    {
        return new Vector2(currentDirection,0);
    }
}
