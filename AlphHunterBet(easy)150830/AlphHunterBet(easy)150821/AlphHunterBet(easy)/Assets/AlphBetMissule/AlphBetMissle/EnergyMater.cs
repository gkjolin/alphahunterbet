using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyMater : MonoBehaviour {
	public string ChildObjectName = "Fill";//sliderの子オブジェクトfillを指定
	public GameObject AlphbetSwitchUI; 
	
	private UsingScript_to_AlphbetSwitch usingScript;
	private GameObject energyMater;
	private Image energyMater_color;
	private int color;
	private Slider compornent_Slider;
	private float maxValue;
	private GameObject player;
	private Rigidbody2D playercollier;
	private string targetAlphbet;

	// Use this for initialization
	void Start () 
	{
		usingScript = AlphbetSwitchUI.GetComponent<UsingScript_to_AlphbetSwitch> ();
		player = usingScript.player;
		playercollier = player.GetComponent<Rigidbody2D> ();
		targetAlphbet = player.GetComponent<PlayerModel> ().Answer;
		compornent_Slider = gameObject.GetComponent<Slider> ();
		maxValue = compornent_Slider.maxValue;
		compornent_Slider.value = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("collition"+playercollier.);
		if (compornent_Slider.value >= maxValue) {
			//energyMater_color.color.r = 230.0f;
		}
		if (playercollier.gameObject.name == targetAlphbet) {
			Debug.Log("collition"+playercollier.gameObject.name);
			compornent_Slider.value += 30f;
		}

	}

}