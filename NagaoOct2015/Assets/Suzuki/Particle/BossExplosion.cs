using UnityEngine;
using System.Collections;

public class BossExplosion : MonoBehaviour {

	[Tooltip("[ParticleSystem] Explosionの役割を持つParticleSystemをいれる.5個まで.")]
	public ParticleSystem[] explosions = new ParticleSystem[5];
	[Tooltip("[ParticleSystem] 最後の演出に使うExplosion(finish)を入れる.")]
	public ParticleSystem explosionF;

	//前に再生したパーティクルシステムの添え字を保存する変数
	private int index;
	//
	private bool flag = true;

	public void ExplosionStart (int arrayIndex){
		if (flag) {
			flag = !flag;
		} else {
			explosions [index].Stop ();
		}
		index = arrayIndex;
		explosions [arrayIndex].Play ();
	}

	public void FinishExplosionStart (){
		explosionF.Play ();
	}

	public void BossHide (){

	}
}
