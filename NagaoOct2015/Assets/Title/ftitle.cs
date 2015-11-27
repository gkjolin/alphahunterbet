using UnityEngine;
using System.Collections;

public class ftitle : MonoBehaviour {

    // Update is called once per frame
    void Update () {
				// mouce clicked
			if (Input.GetMouseButtonDown(0)){
            // scene load
                SceneManagerScript.SetTrigger("Explain");					
			}
        if (Input.GetButtonDown("Fire1"))
        {
            // scene load
            SceneManagerScript.SetTrigger("Explain");
        }

    }
}
