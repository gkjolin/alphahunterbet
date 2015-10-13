using UnityEngine;
using System.Collections;

public class PlayerBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        PlayerModel playerModel = player.GetComponent<PlayerModel>();
        //FirstPlayer firstPlayer = player.GetComponent<FirstPlayerChild> () as FirstPlayer;
        HpBarCtrl hpBarCtrl = GameObject.Find("HpBarCtrl").GetComponent<HpBarCtrl>();
        SaveDoor DoorRefference = GameObject.Find("Manager1").GetComponent<SaveDoor>();
        IAlphabetQueueHandler alphabetQueueHandler = new AlphabetRepeatQueue();
        Animator playerAnimator = player.GetComponent<Animator>();
        IUserInput userInput = player.GetComponent<KeyInput>();
        Rigidbody2D rigidbody2d = player.GetComponent<Rigidbody2D>();
        char_count charCount = GameObject.Find("char_count").GetComponent<char_count>();

        playerAnimator.GetBehaviour<MovePlayerInNormal>().Initialize(userInput, rigidbody2d);
        playerAnimator.GetBehaviour<InEnemyCollision>().Initialize(playerModel, hpBarCtrl, DoorRefference, alphabetQueueHandler);
        charCount.Initialize(alphabetQueueHandler);
    }

}
