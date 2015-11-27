using UnityEngine;
using System.Collections;

public interface IMove {

	float Speed{ get;set; }

	// Update is called once per frame
	void Move2D (Vector2 direction);
}
