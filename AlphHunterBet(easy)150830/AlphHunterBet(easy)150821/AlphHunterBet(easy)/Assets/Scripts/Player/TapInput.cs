using UnityEngine;
using System.Collections;

public class TapInput : MonoBehaviour,IUserInput {
	public Vector2 GetInputVector (){
        return new Vector2(0,0);
	}
}
