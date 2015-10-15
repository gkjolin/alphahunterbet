using UnityEngine;
using System.Collections;

public class GameClear : MonoBehaviour {
	//インスペクターからGameObjectは設定する
	// charge->field->burst
	public GameObject[] particlObj;//particlSystemを持つObj
	public ParticleSystem[] clearParticl;//particlSystemを追加する
	public int nextParticlNumber;//実行するparticlの番号
	public float boosterSpeed;//Booster点火後のspeed
	int screenWidth;
	int screenHeight;
	Vector2 screenCenter;//画面中央
	Vector2 startPosition;//開始場所

	public enum CLEAR{
		NONE=-1,
		WAIT,
		START,
		ANIMATION,
	}
	public CLEAR clearState=CLEAR.NONE;

	// Use this for initialization
	void Start () {
		int i = 0;
		while (i<3) {
			clearParticl[i]=particlObj[i].GetComponent<ParticleSystem>();
			i++;
		}	
	}

	//演出開始 chargeから実行する
	public void startParticl(int particlNumber){
		clearParticl [particlNumber].Play ();//charge演出開始
		particlNumber++;
	}
	//boosterのスピードを調節
	public void boosterControll(int particlNumber){
		clearParticl [particlNumber].startSpeed = boosterSpeed;
	}
}
