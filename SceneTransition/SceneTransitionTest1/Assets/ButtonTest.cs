using UnityEngine;
using System.Collections;

public class ButtonTest : MonoBehaviour {

	void OnButton () {
		SceneManagerScript.GetAnimator ().SetTrigger ("Scene1");
	}
}
