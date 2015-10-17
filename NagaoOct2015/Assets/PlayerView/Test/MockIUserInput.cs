using UnityEngine;
using System.Collections;

public class MockIUserInput : MonoBehaviour,IUserInput {

    public Vector2 GetInputVector()
    {
        return new Vector2(1, 0);
    }


}
