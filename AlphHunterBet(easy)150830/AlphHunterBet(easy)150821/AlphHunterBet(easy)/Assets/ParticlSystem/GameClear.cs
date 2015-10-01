using UnityEngine;
using System.Collections;

public class GameClear : MonoBehaviour {

	//インスペクターからGameObjectは設定する
	// charge->field->burst
	public GameObject[] particlObj;//particlSystemを持つObj
	public ParticleSystem[] clearParticl;//particlSystemを追加する

	// Use this for initialization
	void Start () {
		int i = 0;
		while (i<3) {
			clearParticl[i]=particlObj[i].GetComponent<ParticleSystem>();
			i++;
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator clearSystem{


	}

}
