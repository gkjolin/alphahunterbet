using UnityEngine;

public class ShotAlphabet : MonoBehaviour
{
	//アルファベットが移動する速度
	public int speed = 3;
	//アルファベットが生成されてから消滅するまでの時間
	public float lifeTime = 5;

	void Start ()
	{
		//画面下方向にこのスクリプトを持つGameObjectを移動させる.
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed * (-1);
		//lifeTime時間後に消滅させる.
		Destroy( gameObject, lifeTime);
	}
}