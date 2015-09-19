using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour
{

	public string Answer;
	public int AnswerNumber = 0;
	public int Number;
	public static int StageNumber;
	public int speed = 5;

	Collider2D _collisionData;



	public Collider2D collisionData
	{
		get{
			if (_collisionData == null){
				Debug.Log("_collisionData null");
			}
			return _collisionData;
		}

		set{
			if (value == null){
				Debug.Log("value is null");
			}
			_collisionData = value;
		}
	}


}
