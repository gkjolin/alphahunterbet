using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	
	public void GameOverScreen()
	{
		Application.LoadLevel ("Game_Over");
		Debug.Log ("Game_Over);
	}
}