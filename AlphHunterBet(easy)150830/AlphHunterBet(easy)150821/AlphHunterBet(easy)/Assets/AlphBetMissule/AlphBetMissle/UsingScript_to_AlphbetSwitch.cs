using UnityEngine;
using System.Collections;

//他のオブジェクトへの参照は全てここに集約
public class UsingScript_to_AlphbetSwitch : MonoBehaviour {
	public string stateName_collisionWithDoor = "CollisionWithDoor";//アニメーターステート
	public GameObject player = null;
	public GameObject lunchObject = null;//発射するオブジェクト

}
