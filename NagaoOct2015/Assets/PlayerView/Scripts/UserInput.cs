using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour,IUserInput {

    public Vector2 GetInputVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"),0).normalized;
    }
}
