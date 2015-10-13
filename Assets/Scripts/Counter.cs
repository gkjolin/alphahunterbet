using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
	public static int Count { get; set; }
	
	private void Update()
	{
		GetComponent<GUIText>().text = Count.ToString();
	}
}