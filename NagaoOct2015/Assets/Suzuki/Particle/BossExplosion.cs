using UnityEngine;
using System.Collections;

public class BossExplosion : MonoBehaviour {

	[Tooltip("[ParticleSystem] Explosionの役割を持つParticleSystemをいれる.5個まで.")]
	public ParticleSystem[] explosions = new ParticleSystem[5];
	[Tooltip("[ParticleSystem] 最後の演出に使うExplosion(finish)を入れる.")]
	public ParticleSystem explosionF;

	void ExplosionStart (int arrayIndex){
		explosions [arrayIndex].Play ();
	}
}
