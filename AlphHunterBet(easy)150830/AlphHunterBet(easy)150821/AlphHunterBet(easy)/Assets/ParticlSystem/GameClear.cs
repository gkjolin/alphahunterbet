using UnityEngine;
using System.Collections;

public class GameClear : MonoBehaviour {
	//インスペクターからGameObjectは設定する
	// charge->field->burst
	public GameObject[] particlObj;//particlSystemを持つObj
	public ParticleSystem[] clearParticl;//particlSystemを追加する
	public int nextParticlNumber;//実行するparticlの番号
	public float boosterSpeed;//Booster点火後のspeed max45
	public float boosterSize;//Boosterの火の大きさ max1.5
	public float boosterLifeTime;//Boosterの火の持続時間 max1.0
	bool boosterFire=false;

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
	void Update(){
		if (boosterFire == true) {
			//boosterのspeedをアニメーションにて設定
			clearParticl [nextParticlNumber].startSpeed = boosterSpeed;
			clearParticl[nextParticlNumber].startSize=boosterSize;
			clearParticl[nextParticlNumber].startLifetime=boosterLifeTime;
		}
	}
	//エネルギーを集める animationViewで引数は0を設定
	public void startCharge(int animationEvent_Int){
		clearParticl [animationEvent_Int].Play ();//animation開始
		nextParticlNumber++;//次のアニメーション番号
	}
	//エネルギー開放 animationViewで引数は1を設定
	public void burstForce(int animationEvent_Int){
		clearParticl [nextParticlNumber - 1].Stop ();//前のアニメーションを停止
		clearParticl [animationEvent_Int].Play ();//次のアニメーションを開始
		nextParticlNumber++;//次のアニメーション番号
	}
	//ブースターのアニメーションはｶｯｺよく見せるためにキーフレームでspeedを調整.
	//ブースター点火 updateでspeedを調整 animationViewで引数は2を設定
	public void enagyBoosterFire(int animationEvent_Int){
		clearParticl [nextParticlNumber - 1].Stop ();//前のアニメーション停止
		clearParticl [animationEvent_Int].Play ();//次のアニメーション開始
		boosterFire = true;//Update関数の記述を実行する.
	}
}
