using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour 
{
	
	public int NextStage(int StageNumber)
	{
		StageNumber++;
		Application.LoadLevel ("stage_clear" + StageNumber);
		Debug.Log ("stage_clear" + StageNumber);
		return StageNumber;
	}
}