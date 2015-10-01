using UnityEngine;

public class DestroyArea : MonoBehaviour
{
	void OnTriggerExit2D (Collider2D c)
	{
		Debug.Log (c.ToString ());
		Destroy (c.gameObject, 3);
	}
}