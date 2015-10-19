using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyMater : MonoBehaviour {
	public string ChildObjectName = "Fill";//sliderの子オブジェクトfillを指定
	private GameObject energyMater;
	private Image energyMater_color;
	private int color;

	private Slider compornent_Slider;
	private float maxValue;

	// Use this for initialization
	void Start () 
	{
		compornent_Slider = gameObject.GetComponent<Slider> ();
		maxValue = compornent_Slider.maxValue;
		compornent_Slider.value = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	/*	if (compornent_Slider.value < maxValue) {
			return;
		} else {
			energyMater_color.color.r = 256;
		}
*/
	}

}