using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class char_count : MonoBehaviour {

	char_count cnt;
	static int num = 3;
	//private GameObject target;

	//private GameObject target;

	// Use this for initialization
	void Start () {
		num = 3;
		//target = GameObject.Find("DOOR");
	}
	//void Awake()
	//{
		//target = GameObject.Find("DOOR");
		//target.SetActive(false);
		
	//}
	// Update is called once per frame
	void Update () {
		if(num < 0)
		{
//			target.SetActive(true);

			num = 3;
		}
		GetComponent<Text> ().text = (num).ToString ();
	}
			public int decrease_cnt()
			{
			return char_count.num -= 1;
		}
	public void full_cnt()
	{
		char_count.num = 3;
	}
}
