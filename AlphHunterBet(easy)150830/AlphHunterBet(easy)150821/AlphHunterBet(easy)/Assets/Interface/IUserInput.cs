using System;
using UnityEngine;
using System.Collections;

public interface IUserInput {

	Vector2 GetInputVector ();
	
}

[Serializable]
public class IUserInputContainer : IUnifiedContainer<IUserInput> { }