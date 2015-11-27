using UnityEngine;
using System.Collections;

public class WaitTimer : MonoBehaviour {

	// Use this for initialization

    public bool StartWait()
    {
        StartCoroutine("Wait");
        return true;

    }

	IEnumerable Wait () {
        yield return new WaitForSeconds(2f);
	}


	
}
