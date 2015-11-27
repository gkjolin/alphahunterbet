using UnityEngine;
using System.Collections;

public class MockIUserInput : MonoBehaviour,IUserInput {

    public Vector2 mockInputVector;

    public Vector2 GetInputVector()
    {
        return mockInputVector;
    }


}
