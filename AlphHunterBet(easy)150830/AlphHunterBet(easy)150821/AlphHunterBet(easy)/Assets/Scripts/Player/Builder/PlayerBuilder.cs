using UnityEngine;
using System.Collections;

public class PlayerBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        PlayerModel firstPlayer = player.GetComponent<PlayerModel>();
        //FirstPlayer firstPlayer = player.GetComponent<FirstPlayerChild> () as FirstPlayer;
        HpBarCtrl hpBarCtrl = GameObject.Find("HpBarCtrl").GetComponent<HpBarCtrl>();
        char_count characterCount = GameObject.Find("char_count").GetComponent<char_count>(); ;
        DOOR DoorRefference = GameObject.Find("Manager1").GetComponent<SaveDoor>().DOOR.GetComponent<DOOR>();
        IAlphabetQueueHandler alphabetQueueHandler = new AlphabetQueueHandler();
        Animator playerAnimator = player.GetComponent<Animator>();
        IUserInput userInput = player.GetComponent<KeyInput>();
        Rigidbody2D rigidbody2d = player.GetComponent<Rigidbody2D>();

        playerAnimator.GetBehaviour<MovePlayerInNormal>().Initialize(userInput, rigidbody2d);
        playerAnimator.GetBehaviour<InEnemyCollision>().Initialize(firstPlayer, hpBarCtrl, characterCount, DoorRefference, alphabetQueueHandler);

        characterCount.Initialize(alphabetQueueHandler);
    }

}
