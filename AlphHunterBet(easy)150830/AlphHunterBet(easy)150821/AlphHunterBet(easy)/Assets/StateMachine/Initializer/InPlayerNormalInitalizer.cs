using UnityEngine;
using System.Collections;

public class InPlayerNormalInitalizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("Player");
		Animator playerAnimator = player.GetComponent<Animator> ();

		IUserInput userInput = player.GetComponent<KeyInput> ();
		IMove move = player.GetComponent<PlayerMove> ();

		playerAnimator.GetBehaviour<InPlayerNormal> ().Initialize (userInput,move);
	}
	
}
