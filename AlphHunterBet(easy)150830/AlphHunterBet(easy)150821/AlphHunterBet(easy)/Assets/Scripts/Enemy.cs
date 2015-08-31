using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
	Spaceship spaceship;
	public string alphabet;

	IEnumerator Start (){
		spaceship = GetComponent<Spaceship> ();
		spaceship.Move (transform.up * -1);
		if (spaceship.canShot == false) {
			yield break;
		}
		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);
				spaceship.Shot (shotPosition);
			}
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		// レイヤー名がBullet (Player)以外の時は何も行わない
		if( layerName != "Bullet (Player)") return;

		// 弾の削除
		Destroy(c.gameObject);

		// 爆発
		spaceship.Explosion();
		
		// エネミーの削除
		Destroy(gameObject);
	}
}