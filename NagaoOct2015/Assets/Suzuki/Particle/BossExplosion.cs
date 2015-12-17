using UnityEngine;
using System.Collections;

public class BossExplosion : MonoBehaviour {

	[Tooltip("[int] Bossに持たせるParticleSystemの個数")]
	public int explosionNum;
	[Tooltip("[ParticleSystem] Explosionの役割を持つParticleSystemをいれる.")]
	public ParticleSystem[] explosions;
	[Tooltip("[ParticleSystem] 最後の演出に使うExplosion(finish)を入れる.")]
	public ParticleSystem explosionF;

	void Start (){
		explosions = new ParticleSystem[explosionNum];
	}
}
