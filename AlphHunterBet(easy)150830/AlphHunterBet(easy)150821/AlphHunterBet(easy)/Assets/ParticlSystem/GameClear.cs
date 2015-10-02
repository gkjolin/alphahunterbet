using UnityEngine;
using System.Collections;

public class GameClear : MonoBehaviour {

	//インスペクターからGameObjectは設定する
	// charge->field->burst
	public GameObject[] particlObj;//particlSystemを持つObj
	public ParticleSystem[] clearParticl;//particlSystemを追加する
	public int nextParticlNumber;//実行するparticlの番号
	float durationTime=0;//持続し続けた時間
	float durationMaxTime;//最大持続時間
	float fieldOpenTime=0;//
	float fieldOpenMaxTime;//
	float boosterSpeed;//Booster点火後のspeed
	float boosterMaxSpeed=7.0f;//MaxSpeed

	public enum CLEAR{
		NONE=-1,
		START,
		CHARGE,
		FIELD,
		BOOSTER,
	}
	public CLEAR clearState=CLEAR.NONE;

	// Use this for initialization
	void Start () {
		int i = 0;
		while (i<3) {
			clearParticl[i]=particlObj[i].GetComponent<ParticleSystem>();
			i++;
		}
		clearState = CLEAR.START;
	}
	
	// Update is called once per frame
	void Update () {
		clearEffectStateChange ();
	}
	//クリア演出のstateの変更
	void clearEffectStateChange(){

		switch (clearState) {

		case CLEAR.START:
			nextParticlNumber=0;
			startParticl(nextParticlNumber);
			break;

		case CLEAR.CHARGE:
			chargeControll(nextParticlNumber);
			break;

		case CLEAR.FIELD:
			fieldOpenControll(nextParticlNumber);
			break;

		case CLEAR.BOOSTER:
			boosterControll(nextParticlNumber);
			break;
		}

	}
	//演出開始 chargeから実行する
	void startParticl(int particlNumber){
		clearParticl [particlNumber].Play ();//charge演出開始
		clearState = CLEAR.CHARGE;//chargeﾓｰﾄﾞへ移行
		durationMaxTime = clearParticl [particlNumber].duration*1.25f;//演出時間をdurationから取得
	}

	//powerChargeの時間とfiled展開までの処理
	void chargeControll(int particlNumber){
		durationTime += 1 * Time.deltaTime;//開始
		//チャージ時間マックスになれば判定
		if (durationTime >= durationMaxTime) {
			clearParticl[particlNumber].Stop();//particlをStop
			nextParticlNumber++;//次の配列移動のために++
			clearState=CLEAR.FIELD;//フィールドをオープンするﾓｰﾄﾞへ
		}
	}
	//forceFieldを展開する
	void fieldOpenControll(int particlNumber){
		clearParticl [particlNumber].Play ();//開始
		fieldOpenMaxTime=clearParticl[particlNumber].duration+1f;
		fieldOpenTime+=1 * Time.deltaTime;
		//fieldオープン時間がマックスになれば判定
		if (fieldOpenTime >= fieldOpenMaxTime) {
			clearParticl[particlNumber].Stop();//particlをStop
			nextParticlNumber++;
			clearState = CLEAR.BOOSTER;//ﾌﾞｰｽﾀｰﾓｰﾄﾞへ
		}
	}
	//boosterのスピードを調節
	void boosterControll(int particlNumber){
		clearParticl [particlNumber].Play ();
		//最大速度の1/4まで加速
		if (boosterSpeed <= boosterMaxSpeed/8) {
			boosterSpeed += 1f * Time.deltaTime*0.85f;
			clearParticl [particlNumber].startSpeed = boosterSpeed;
			//最大速度まで加速
		} else if(boosterSpeed<=boosterMaxSpeed){
			boosterSpeed += 1f * Time.deltaTime*25f;
			clearParticl [particlNumber].startSpeed = boosterSpeed;
		}
	}
}
