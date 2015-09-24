using UnityEngine;
using System.Collections;

public class MovePlayerInNormalInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("Player");
		Animator playerAnimator = player.GetComponent<Animator> ();

		IUserInput userInput = player.GetComponent<TapInput> ();
		Rigidbody2D rigidbody2d = player.GetComponent<Rigidbody2D> ();

		playerAnimator.GetBehaviour<MovePlayerInNormal> ().Initialize (userInput,rigidbody2d);
	}
	
}
