using UnityEngine;
using System.Collections;

public class DefeatDirection : MonoBehaviour {

	public ParticleSystem[] defeatParticle=new ParticleSystem[2];
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer=GetComponent<SpriteRenderer>();//spriteRendererを取得
	//ParticleSystemを取得
		for(int i=0;i<defeatParticle.Length;i++){
			defeatParticle[i]=gameObject.transform.GetChild(i).GetComponent<ParticleSystem>();
		}
	}

	//最初の爆発
	public void startExplo(){
		defeatParticle [0].Play ();
	}
	//ラストのおっきな爆発
	public void stopExploAndFinish(){
		defeatParticle [0].Stop ();
		defeatParticle [1].Play ();
	}
	//spriteを爆発に合わせて消す
	//色を赤にする.
	public void playerColorRed(){
		spriteRenderer.color =Color.red;
	}
	//spriteを非表示にする.
	public void playerSpriteEnableFalse(){
		spriteRenderer.color = Color.white;
		spriteRenderer.enabled = false;
	}
}
